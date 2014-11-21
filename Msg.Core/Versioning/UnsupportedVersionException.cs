using System;
using Version = Msg.Core.Versioning;
using System.Runtime.Serialization;

namespace Msg.Core.Versioning
{
	public class UnsupportedVersionException : Exception
	{
		public UnsupportedVersionException ()
			: base("Version is not supported.")
		{
		}

		public UnsupportedVersionException (Version version)
			: base (string.Format ("Version {0} is not supported.", version))
		{
		}

		protected UnsupportedVersionException (SerializationInfo info, StreamingContext context)
			: base (info, context)
		{
		}
	}
}

