using System;
using System.Threading.Tasks;

namespace Msg.Core.Transport.Connections.Common
{
    public interface ITransportLayerConnectionFactory
    {
        Task<ITransportLayerConnection> OpenConnectionAsync();
    }
}