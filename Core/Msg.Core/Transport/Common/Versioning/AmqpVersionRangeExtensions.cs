using System.Collections.Generic;
using System.Linq;

namespace Msg.Core.Transport.Common.Versioning
{
    public static class AmqpVersionRangeExtensions
    {
        public static AmqpVersionRange To (this AmqpVersionRange versionRange, byte major, byte minor, byte revision)
        {
            return new AmqpVersionRange (versionRange.LowerBoundInclusive, new AmqpVersion (major, minor, revision));
        }

        public static bool HasVersionMatching(this IEnumerable<AmqpVersionRange> supportedVersions, AmqpVersion version)
        {
            return supportedVersions.Any (versionRange => versionRange.Contains (version));
        }

        public static AmqpVersion GetHighestVersion(this IEnumerable<AmqpVersionRange> supportedVersions)
        {
            return supportedVersions
                .OrderBy (x => x.UpperBoundInclusive)
                .First ()
                .UpperBoundInclusive;
        }
    }
}