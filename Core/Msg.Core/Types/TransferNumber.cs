namespace Msg.Core.Types
{
    public struct TransferNumber
    {
        public string Value { get; }

        public TransferNumber(string value)
        {
            Value = value;
        }
    }
}
