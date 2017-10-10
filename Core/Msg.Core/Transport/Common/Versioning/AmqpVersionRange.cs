namespace Msg.Core.Transport.Common.Versioning
{
    public class AmqpVersionRange
    {
        public AmqpVersionRange (AmqpVersion lowerBoundExclusive, AmqpVersion upperBoundInclusive)
        {
            this.LowerBoundInclusive = lowerBoundExclusive;
            this.UpperBoundInclusive = upperBoundInclusive;
        }

        public AmqpVersion LowerBoundInclusive { get; }

        public AmqpVersion UpperBoundInclusive { get; }

        public bool Contains (AmqpVersion version)
        {
            return (LowerBoundInclusive == AmqpVersion.Any || version > LowerBoundInclusive || version == LowerBoundInclusive)
            && (UpperBoundInclusive == AmqpVersion.Any || version < UpperBoundInclusive || version == UpperBoundInclusive);
        }
    }

    
}

