using System.Net;
using Msg.Core.Transport.Common;
namespace Msg.Core.Transport.Connections.Tcp
{
    public class UninitializedTcpConnection : UninitializedConnection, ITcpConnection
    {
        public IPAddress IpAddress { get; }
        public PortNumber PortNumber { get; }

        public UninitializedTcpConnection(IPAddress ipAddress, PortNumber portNumber)
        {
            IpAddress = ipAddress;
            PortNumber = portNumber;
        }

        protected override string ExceptionMessageTemplate {
            get {
                return "Cannot call {0} on an uninitialized TCP connection.";
            }
        }
    }
}
