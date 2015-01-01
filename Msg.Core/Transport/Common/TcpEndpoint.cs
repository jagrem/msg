using System.Net;

namespace Msg.Core.Transport.Common
{
    public class TcpEndpoint
    {
        public TcpEndpoint (IPAddress ipAddress, PortNumber port)
        {
            this.IpAddress = ipAddress;
            this.Port = port;
        }

        public IPAddress IpAddress { get; private set; }

        public PortNumber Port { get; private set; }
    }
}

