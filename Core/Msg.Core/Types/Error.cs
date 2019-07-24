namespace Msg.Core.Types
{
    public struct Error
    {
        public string Value { get; }

        public Error(string value)
        {
            Value = value;
        }
    }
}
