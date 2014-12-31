using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Msg.Core.Transport.Connections.Tcp
{
    public class TcpConnection : Connection
    {
        public override async Task<byte[]> SendAsync (byte[] message)
        {
            var client = new TcpClient ();
            await client.ConnectAsync (IPAddress.Loopback, 9876);
            using (var stream = client.GetStream ()) {
                await stream.WriteAsync (message, 0, message.Length);
            }
            client.Close ();
            return new byte[0];
        }
    }
}

