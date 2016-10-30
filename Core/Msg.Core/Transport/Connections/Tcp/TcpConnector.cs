using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Msg.Core.Transport.Common;
namespace Msg.Core.Transport.Connections.Tcp
{
    public static class TcpConnector
    {
        public async static Task<TcpConnection> OpenConnectionAsync(IPAddress ipAddress, PortNumber portNumber)
        {
            var client = new TcpClient ();
            await client.ConnectAsync (ipAddress, portNumber);
            return new TcpConnection (client);
        }
    }
}
