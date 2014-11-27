using Msg.Core.Transport.Frames;
using Msg.Core.Transport;
using NSubstitute;
using System.Threading.Tasks;
using System;

namespace Msg.Core.Specs.Transport.Connections.Replay
{
    public static class ReplayConnectionExtensions
    {
        public static IConnection Connect (this IConnection connection)
        {
            connection.IsConnected.Returns (true);
            connection.IsClosed.Returns (false);
            return connection;
        }

        public static IConnection Expect (this IConnection connection, Frame frame)
        {
            connection.SendAsync (frame.GetBytes ());
            return connection;
        }

        public static IConnection ThrowAnyException(this IConnection connection)
        {
            connection.SendAsync (Arg.Any<byte[]> ())
                .Returns (new Task<byte[]>(() => { throw new Exception(); }));
            return connection;
        }

        public static IConnection Close(this IConnection connection)
        {
            connection.IsClosed.Returns (true);
            connection.IsConnected.Returns (false);
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
