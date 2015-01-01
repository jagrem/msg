using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Version = Msg.Core.Versioning;

namespace Msg.Core.Versioning
{

    public static class ServerSupportedVersionsExtensions {

        public static bool Contains(this ServerSupportedVersions supportedVersions, Version version)
        {
            supportedVersions.Any (versionRange => versionRange.Contains (version));
        }

        public static ServerVersion GetHighestVersion(this ServerSupportedVersions supportedVersions)
        {
            var highestSupportedVersion = supportedVersions
                .OrderBy (x => x.UpperBoundInclusive)
                .First ()
                .UpperBoundInclusive;

            return new ServerVersion (highestSupportedVersion);
        }
    }
}
