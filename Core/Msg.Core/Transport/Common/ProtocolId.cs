namespace Msg.Core.Transport.Common
{
    public class ProtocolId
    {
        readonly byte value;

        public ProtocolId (byte value)
        {
            this.value = value;
        }

        public static implicit operator byte (ProtocolId id)
        {
            return id.value;
        }

        public static explicit operator ProtocolId (byte id)
        {
            return new ProtocolId (id);
        }

        public override bool Equals (object obj)
        {
            var protocolId = obj as ProtocolId;
            return protocolId != null && value.Equals (protocolId.value);
        }

        public override int GetHashCode ()
        {
            return value.GetHashCode ();
        }
    }
}
