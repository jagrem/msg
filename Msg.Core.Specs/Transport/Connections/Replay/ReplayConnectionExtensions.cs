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
            connection.Replay (message => {
                throw exception;
            });
            return connection;
        }

        public static ReplayConnection ThrowAnyException (this ReplayConnection connection)
        {
            connection.Replay (message => {
                throw new Exception ();
            });
            return connection;
        }

        public static ReplayConnection ReplyWithFrame (this ReplayConnection connection, Frame expectedFrame, Frame responseFrame)
        {
            connection.Replay (actualBytes => {
                var expectedBytes = expectedFrame.GetBytes ();
                AssertAreEqual (expectedBytes, actualBytes);
                return responseFrame.GetBytes ();
            });
            return connection;
        }

        public static ReplayConnection Acknowledge (this ReplayConnection connection, Frame expectedFrame, bool shouldClose)
        {
            connection.Replay (actualBytes => {
                var expectedBytes = expectedFrame.GetBytes ();
                AssertAreEqual (expectedBytes, actualBytes);
                if (shouldClose)
                    connection.Close ();
                return null;
            });

            return connection;
        }

        public static ReplayConnection AcknowledgeAndClose (this ReplayConnection connection, Frame expectedFrame)
        {
            connection.Acknowledge (expectedFrame, true);
            return connection;
        }

        public static ReplayConnection AcknowledgeButDontClose (this ReplayConnection connection, Frame expectedFrame)
        {
            connection.Acknowledge (expectedFrame, false);
            return connection;
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
