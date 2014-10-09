using System;

namespace Msg.Domain
{
	public class Version
	{
		static readonly byte[] AMQP = { 0x41, 0x4D, 0x51, 0x50 };

		public Version(byte major, byte minor, byte revision)
		{
			this.Major = major;
			this.Minor = minor;
			this.Revision = revision;
		}

		public byte Major { get; private set; }

		public byte Minor { get; private set; }

		public byte Revision { get; private set; }

		public static implicit operator byte[](Version v)
		{
			return new byte[] { AMQP[0], AMQP[1], AMQP[2], AMQP[3], 0, v.Major, v.Minor, v.Revision };
		}

		public static implicit operator Version(byte[] v)
		{
			if(v.Length != 8) {
				throw new ArgumentException ("Version must be exactly 8 bytes.");
			}

			if (!(v [0] == AMQP [0] && v [1] == AMQP [1] && v [2] == AMQP [2] && v [3] == AMQP [3] && v [4] == 0)) {
				throw new ArgumentException ("Version must start with \"AMQP\" followed by zero.");
			}

			return new Version (v [5], v [6], v [7]);
		}
	}
}

