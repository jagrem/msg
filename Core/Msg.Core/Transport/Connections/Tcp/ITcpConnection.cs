using System.Net;
using Msg.Core.Transport.Connections.Common;
namespace Msg.Core.Transport.Connections.Tcp
{
    public interface ITcpConnection : ITransportLayerConnection
    {
        IPAddress IpAddress { get; }
        PortNumber PortNumber { get; }
    }
}
