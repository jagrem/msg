namespace Msg.Core.Versioning
{
    public class VersionRange
    {
        public VersionRange (Version lowerBoundExclusive, Version upperBoundInclusive)
        {
            this.LowerBoundInclusive = lowerBoundExclusive;
            this.UpperBoundInclusive = upperBoundInclusive;
        }

        public Version LowerBoundInclusive { get; private set; }

        public Version UpperBoundInclusive { get; private set; }

        public bool Contains (Version version)
        {
            return (LowerBoundInclusive == Version.Any || version > LowerBoundInclusive || version == LowerBoundInclusive)
            && (UpperBoundInclusive == Version.Any || version < UpperBoundInclusive || version == UpperBoundInclusive);
        }
    }

    public static class VersionRangeExtensions
    {
        public static VersionRange To (this VersionRange versionRange, byte major, byte minor, byte revision)
        {
            return new VersionRange (versionRange.LowerBoundInclusive, new Version (major, minor, revision));
        }
    }
}

