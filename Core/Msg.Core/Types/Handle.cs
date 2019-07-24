namespace Msg.Core.Types
{
    public struct Handle
    {
        public long Value { get; }

        public Handle(long value)
        {
            Value = value;
        }
    }
}
