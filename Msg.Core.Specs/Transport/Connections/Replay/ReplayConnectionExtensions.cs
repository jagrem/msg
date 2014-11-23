using System;
using Msg.Core.Transport.Frames;

namespace Msg.Core.Specs.Transport.Connections.Replay
{
    public static class ReplayConnectionExtensions
    {
        public static ReplayConnection AllowClientToConnect (this ReplayConnection connection)
        {
            connection.Open ();
            return connection;
        }

        public static ReplayExpectation Expect (this ReplayConnection connection, Frame frame)
        {
            return new ReplayExpectation (connection, frame);
        }

        public static ReplayConnection ThrowException (this ReplayConnection connection, Exception exception)
        {
            return connection.Record (message => {
                throw exception;
            });
        }

        public static ReplayConnection ThrowAnyException (this ReplayConnection connection)
        {
            return ThrowException (connection, new Exception ());
        }

        public static ReplayConnection ReplyWithFrame (this ReplayConnection connection, Frame expectedFrame, Frame responseFrame)
        {
            return connection.Record (actualBytes => {
                var expectedBytes = expectedFrame.GetBytes ();
                AssertAreEqual (expectedBytes, actualBytes);
                return responseFrame.GetBytes ();
            });
        }

        public static ReplayConnection Acknowledge (this ReplayConnection connection, Frame expectedFrame, bool shouldClose)
        {
            return connection.Record (actualBytes => {
                var expectedBytes = expectedFrame.GetBytes ();
                AssertAreEqual (expectedBytes, actualBytes);
                if (shouldClose)
                    connection.Close ();
                return null;
            });
        }

        public static ReplayConnection AcknowledgeAndClose (this ReplayConnection connection, Frame expectedFrame)
        {
            return connection.Acknowledge (expectedFrame, true);
        }

        public static ReplayConnection AcknowledgeButDontClose (this ReplayConnection connection, Frame expectedFrame)
        {
            return connection.Acknowledge (expectedFrame, false);
        }

        static void AssertAreEqual (byte[] expected, byte[] actual)
        {
            if (expected.Length != actual.Length) {
                throw new ReplayException (expected, actual);
            }

            for (int i = 0; i < expected.Length; i++) {
                if (expected [i] != actual [i]) {
                    throw new ReplayException (expected, actual);
                }
            }
        }
    }
}
