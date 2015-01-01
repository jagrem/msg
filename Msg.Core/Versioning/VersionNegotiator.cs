using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Version = Msg.Core.Versioning;

namespace Msg.Core.Versioning
{
    public static class VersionNegotiator
    {
        public static async Task<Version> NegotiateVersionAsync (IEnumerable<VersionRange> supportedVersions)
        {
            return await Task.FromResult (supportedVersions.First ().UpperBoundInclusive);
        }

        public static Version Select (ClientVersion client, ServerSupportedVersions server)
        {
            return new ServerVersion(0,0,0);
        }
    }
}

