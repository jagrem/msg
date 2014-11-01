using System;

namespace Msg.Domain.Transport.Frames
{

	public static class ByteArrayExtensions
	{
		public static uint ReadInt32(this byte[] bytes, int offset)
		{
			if(bytes == null){
				throw new ArgumentNullException ("bytes");
			}

			if(bytes.Length < 1){
				throw new ArgumentException ("Array was empty");
			}

			if(offset < 0) {
				throw new ArgumentOutOfRangeException ("offset");
			}

			if(offset >= bytes.Length) {
				throw new ArgumentOutOfRangeException ("offset");
			}

			if(bytes.Length - (offset + 1) < 4){
				throw new ArgumentOutOfRangeException ("offset");
			}

			var integerBytes = new byte[4];
			Array.Copy (bytes, offset, integerBytes, 0, 4);

			uint value = 0;
			value |= (uint)integerBytes [3] << 0;
			value |= (uint)integerBytes [2] << 8;
			value |= (uint)integerBytes [1] << 16;
			value |= (uint)integerBytes [0] << 24;
			return value;
		}
	}
}
