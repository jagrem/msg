using Msg.Core.Transport.Frames;
using System.Threading.Tasks;
using Msg.Core.Transport.Frames.Factories;
using System;
using Msg.Core.Transport.Connections.Tcp;
using Msg.Core.Transport.Connections.Http;
using Msg.Core.Transport.Connections.WebSockets;

namespace Msg.Core.Transport.Connections
{
    public static class Connector
    {
        public static async Task<IConnection> OpenConnectionAsync (IConnection connection)
        {
            try {
                connection = await OpenUnderlyingConnectionAsync (connection);
                await SendOpenFrame (connection);
                return new OpenConnection (connection);
            } catch (Exception exception) {
                throw new OpenConnectionFailedException ("Connection failed.", exception);
            }
        }

        static async Task<IConnection> OpenUnderlyingConnectionAsync (IConnection connection)
        {
            if (!(connection is UninitializedConnection)) {
                throw new InvalidOperationException ("Cannot re-open an existing connection.")
;            }

            if (connection is ITcpConnection) {
                var uninitializedTcpConnection = connection as ITcpConnection;
                return await TcpConnector.OpenConnectionAsync (uninitializedTcpConnection.IpAddress, uninitializedTcpConnection.PortNumber);
            }

            if (connection is IHttpConnection) {
                throw new NotSupportedException ("HTTP connections are not yet supported.");
            }

            if (connection is IWebSocketConnection) {
                throw new NotSupportedException ("WebSocket connections are not yet supported.");
            } 

            throw new NotSupportedException ("This type of connection is not yet supported.");
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