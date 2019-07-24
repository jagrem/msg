namespace Msg.Core.Types
{
    public struct Millisecond
    {
        public long Value { get; }

        public Millisecond(long value)
        {
            Value = value;
        }
    }
}
