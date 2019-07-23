using System.Threading.Tasks;
using System.Net;
using Msg.Core.Transport.Connections.Tcp;
using Msg.Core.Transport.Common;

namespace Msg.Core.Transport.Connections.Common
{
    public class TransportLayerConnectionFactory : ITransportLayerConnectionFactory
    {
        public async Task<ITransportLayerConnection> OpenConnectionAsync()
        {
            return await TcpConnector.OpenConnectionAsync(IPAddress.Loopback, (PortNumber)9876); 
        }
    }
}