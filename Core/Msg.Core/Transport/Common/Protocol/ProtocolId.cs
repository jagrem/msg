using System;

namespace Msg.Core.Transport.Common.Protocol
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

        public static bool operator ==(ProtocolId left, ProtocolId right) =>
            !ReferenceEquals(left, null)
            && !ReferenceEquals(right, null)
            && left.Equals(right);

        public static bool operator !=(ProtocolId left, ProtocolId right) =>
            !(left == right);

        public override int GetHashCode ()
        {
            return value.GetHashCode ();
        }
    }
}
