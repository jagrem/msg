namespace Msg.Core.Common
{
    public struct Option<T>
    {
        public T Value { get; }

        public Option(T value)
        {
            Value = value;
        }
    }
}
