using System.Threading.Tasks;
using System.Net.Sockets;
using System;
using Msg.Core.Transport.Common;
using Msg.Core.Transport.Connections.Common;
using System.Net;

namespace Msg.Core.Transport.Connections.Tcp
{
    public class TcpConnection : ITransportLayerConnection
    {
        readonly TcpClient client;
        bool disposedValue = false;

        public TcpConnection (TcpClient client)
        {
            this.client = client;
        }

        public async Task<long> SendAsync (byte [] message)
        {
            using (var stream = client.GetStream ()) {
                await stream.WriteAsync (message, 0, message.Length);
            }

            return message.Length;
        }

        public async Task<byte[]> ReceiveAsync (long count)
        {
            var countInt32 = Convert.ToInt32(count);
            using(var stream = client.GetStream()) {
                var buffer = new byte [countInt32];
                await stream.ReadAsync(buffer, 0, countInt32);
                return buffer;
            }
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
