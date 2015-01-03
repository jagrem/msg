using Msg.Core.Transport.Frames;
using System.Threading.Tasks;
using Msg.Core.Transport.Frames.Factories;
using Msg.Core.Transport;
using System;

namespace Msg.Core.Transport.Connections
{
    public static class Connector
    {
        public static async Task<IConnection> OpenConnectionAsync (IConnection connection)
        {
            try {
                await SendOpenFrame (connection);
                return new OpenConnection (connection);
            } catch (Exception exception) {
                throw new OpenConnectionFailedException ("Connection failed.", exception);
            }
        }

        static async Task SendOpenFrame (IConnection connection)
        {
            var openFrame = FrameFactory.CreateOpenFrame ();
            await FrameSender.SendFrame (connection, openFrame);
        }

        public static async Task<IConnection> CloseConnectionAsync (IConnection connection)
        {
            try {
                await SendCloseFrame (connection);
                return new ClosedConnection ();
            } catch (Exception exception) {
                throw new CloseConnectionFailedException ("Closing connection failed.", exception);
            }
        }

        static async Task SendCloseFrame (IConnection connection)
        {
            var closeFrame = FrameFactory.CreateCloseFrame ();
            await FrameSender.SendFrame (connection, closeFrame);
        }
    }

}