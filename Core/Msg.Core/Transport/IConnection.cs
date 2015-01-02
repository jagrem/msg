using System.Threading.Tasks;
using System.Collections.Generic;
using Msg.Core.Versioning;

namespace Msg.Core.Transport
{
    public interface IConnection
    {
        bool IsConnected { get; }

        bool IsClosed { get; }

        long MaximumFrameSize { get; }

        Version Version { get; }

        IEnumerable<VersionRange> SupportedVersions { get; }

        Task<byte[]> SendAsync (byte[] message);
    }
}