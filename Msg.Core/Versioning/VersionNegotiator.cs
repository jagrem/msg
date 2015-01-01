using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Version = Msg.Core.Versioning;

namespace Msg.Core.Versioning
{
    public static class VersionNegotiator
    {
        [System.Obsolete("This method is deprecated us VersionNegotiator.Select instead.")]
        public static async Task<Version> NegotiateVersionAsync (IEnumerable<VersionRange> supportedVersions)
        {
            return await Task.FromResult (supportedVersions.First ().UpperBoundInclusive);
        }

        public static Version Select (ClientVersion clientVersion, ServerSupportedVersions serverSupportedVersions)
        {
            var serverVersion = GetDefaultServerVersion (serverSupportedVersions);
            return clientVersion == serverVersion ? new AcceptedVersion (clientVersion) : serverVersion;
        }

        static ServerVersion GetDefaultServerVersion (IEnumerable<VersionRange> supportedVersions)
        {
            var highestSupportedVersion = supportedVersions
                .OrderBy (x => x.UpperBoundInclusive)
                .First ()
                .UpperBoundInclusive;

            return new ServerVersion (highestSupportedVersion.Major, highestSupportedVersion.Minor, highestSupportedVersion.Revision);
        }
    }
}

