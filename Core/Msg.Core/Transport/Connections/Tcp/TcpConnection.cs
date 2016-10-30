using System.Threading.Tasks;
using System.Net.Sockets;
using System;
using Msg.Core.Transport.Common;
using System.Net;

namespace Msg.Core.Transport.Connections.Tcp
{
    public class TcpConnection : Connection, IDisposable, ITcpConnection
    {
        readonly TcpClient client;
        bool disposedValue = false;

        public IPAddress IpAddress {
            get {
                throw new NotImplementedException ();
            }
        }

        public PortNumber PortNumber {
            get {
                throw new NotImplementedException ();
            }
        }

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
