using System;
using Msg.Core.Transport.Common.Versioning;

namespace Msg.Core.Transport.Common.Protocol
{
    public class ProtocolHeader
    {
        static readonly byte [] AMQP = { 0x41, 0x4D, 0x51, 0x50 };

        public ProtocolHeader (ProtocolId id, AmqpVersion version)
        {
            ProtocolId = id;
            Version = version;
        }

        public ProtocolId ProtocolId { get; private set; }

        public AmqpVersion Version { get; private set; }

        public static implicit operator byte [] (ProtocolHeader value)
        {
            var version = (byte [])value.Version;
            return new [] { AMQP [0], AMQP [1], AMQP [2], AMQP [3], (byte)value.ProtocolId, version [0], version [1], version [2] };
        }

        public static explicit operator ProtocolHeader (byte [] value)
        {
            if (value.Length != 8) {
                throw new ArgumentException ("Protocol header must be exactly 8 bytes.");
            }

            if (!(value [0] == AMQP [0] && value [1] == AMQP [1] && value [2] == AMQP [2] && value [3] == AMQP [3])) {
                throw new ArgumentException ("Protocol header must start with \"AMQP\".");
            }

            return new ProtocolHeader (new ProtocolId (value [4]), new AmqpVersion (value [5], value [6], value [7]));
        }
    }
}
