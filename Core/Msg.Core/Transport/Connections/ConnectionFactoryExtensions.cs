using System.Threading.Tasks;
using Msg.Core.Transport.Connections.Tcp;
using Msg.Core.Transport.Connections.Http;
using Msg.Core.Transport.Connections.WebSockets;
using System.Net;
using Msg.Core.Transport.Common;

namespace Msg.Core.Transport.Connections
{
    public static class ConnectionFactoryExtensions
    {
        public static async Task<IConnection> CreateConnectionAsync (this ConnectionFactory factory)
        {
            /* defaults to TCP connection for the moment */
            return await factory.CreateTcpConnectionAsync ();
        }

        public static async Task<IConnection> CreateTcpConnectionAsync (this ConnectionFactory factory)
        {
            return await TcpConnectionFactory.CreateTcpConnectionAsync (IPAddress.Loopback, (PortNumber)9876);
        }

        public static async Task<IConnection> CreateHttpConnectionAsync (this ConnectionFactory factory)
        {
            // TODO: Replace with implementation to create wrapper for HTTP long-polling connection.
            await Task.Yield ();
            return new HttpConnection ();
        }

        public static async Task<IConnection> CreateWebSocketConnectionAsync (this ConnectionFactory factory)
        {
            // TODO: Replace with implementation to create WebSockets connection.
            await Task.Yield ();
            return new WebSocketConnection ();
        }
    }
}
