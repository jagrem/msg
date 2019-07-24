namespace Msg.Core.Types
{
    public struct IETFLanguageTag
    {
        public string Value { get; }

        public IETFLanguageTag(string value)
        {
            Value = value;
        }
    }
}
