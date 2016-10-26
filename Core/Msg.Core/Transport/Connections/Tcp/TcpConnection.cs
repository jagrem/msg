using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System;

namespace Msg.Core.Transport.Connections.Tcp
{
    public class TcpConnection : Connection, IDisposable
    {
        readonly NetworkStream stream;
        bool disposedValue = false;

        public TcpConnection (NetworkStream stream)
        {
            this.stream = stream;
        }

        public override async Task<byte []> SendAsync (byte [] message)
        {
            var client = new TcpClient ();
            await client.ConnectAsync (IPAddress.Loopback, 9876);
            using (var stream = client.GetStream ()) {
                await stream.WriteAsync (message, 0, message.Length);
            }
            client.Close ();
            return new byte [0];
        }

        protected virtual void Dispose (bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    stream.Dispose ();
                }

                disposedValue = true;
            }
        }

        public void Dispose ()
        {
            Dispose (true);
        }
    }
}
