using System.Threading.Tasks;
using System.Net.Sockets;
using System;

namespace Msg.Core.Transport.Connections.Tcp
{
    public class TcpConnection : Connection, IDisposable
    {
        readonly TcpClient client;
        bool disposedValue = false;

        public TcpConnection (TcpClient client)
        {
            this.client = client;
        }

        public override async Task<byte []> SendAsync (byte [] message)
        {
            using (var stream = client.GetStream ()) {
                await stream.WriteAsync (message, 0, message.Length);
            }

            return new byte [0];
        }

        protected virtual void Dispose (bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    client.Close ();
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
