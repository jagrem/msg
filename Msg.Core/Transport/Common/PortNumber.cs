using System;

namespace Msg.Core.Transport.Common
{
    public class PortNumber
    {
        readonly int number;

        public PortNumber(int number)
        {
            this.number = number;
        }

        public static implicit operator int(PortNumber port)
        {
            return port.number;
        }

        public static explicit operator PortNumber(int number)
        {
            if (number <= 0 || number > 65535)
                throw new ArgumentOutOfRangeException ("number", "Port numbers must be between 0 and 65535.");

            return new PortNumber (number);
        }
    }
}

