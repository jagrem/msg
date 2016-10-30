using Msg.Core.Transport.Connections.Tcp;
using Msg.Core.Transport.Connections.Http;
using Msg.Core.Transport.Connections.WebSockets;
using System.Net;
using Msg.Core.Transport.Common;

namespace Msg.Core.Transport.Connections
{
    public static class ConnectionFactoryExtensions
    {
        public static IConnection CreateConnection (this ConnectionFactory factory)
        {
            /* defaults to TCP connection for the moment */
            return factory.CreateTcpConnection ();
        }

        public static IConnection CreateTcpConnection (this ConnectionFactory factory)
        {
            return new UninitializedTcpConnection (IPAddress.Loopback, (PortNumber)9876);
        }

        public static IConnection CreateHttpConnection (this ConnectionFactory factory)
        {
            // TODO: Replace with implementation to create wrapper for HTTP long-polling connection.
            return new UninitializedHttpConnection ();
        }

        public static IConnection CreateWebSocketConnection (this ConnectionFactory factory)
        {
            // TODO: Replace with implementation to create WebSockets connection.
            return new UninitializedWebSocketConnection ();
        }
    }
}
