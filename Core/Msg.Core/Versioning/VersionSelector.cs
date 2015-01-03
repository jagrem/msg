using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Version = Msg.Core.Versioning;

namespace Msg.Core.Versioning
{
    public static class VersionSelector
    {
        [System.Obsolete ("This method is deprecated us VersionNegotiator.Select instead.")]
        public static async Task<Version> NegotiateVersionAsync (IEnumerable<VersionRange> supportedVersions)
        {
            return await Task.FromResult (supportedVersions.First ().UpperBoundInclusive);
        }

        public static Version Select (ClientVersion clientVersion, ServerSupportedVersions supportedVersions)
        {
            if (clientVersion.IsNotMalformed () && supportedVersions.HasVersionMatching (clientVersion))
                return new AcceptedVersion (clientVersion);

            return supportedVersions.GetHighestVersion ();
        }
    }
}

