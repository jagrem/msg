using System.Net;
using Msg.Core.Transport.Common;
namespace Msg.Core.Transport.Connections.Tcp
{
    public interface ITcpConnection
    {
        IPAddress IpAddress { get; }
        PortNumber PortNumber { get; }
    }
}
