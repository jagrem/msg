using System;
using System.Threading.Tasks;

namespace Msg.Core.Transport.Connections.Common
{
    public interface ITransportLayerConnection : IDisposable
    {
        Task<long> SendAsync(byte[] message);
        Task<byte[]> ReceiveAsync(long count);
    }
}