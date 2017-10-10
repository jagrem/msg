using System;
using System.Runtime.Serialization;

namespace Msg.Core.Transport.Common.Versioning
{
    public class UnsupportedVersionException : Exception
    {
        public UnsupportedVersionException ()
            : base ("Version is not supported.")
        {
        }

        public UnsupportedVersionException (AmqpVersion preferedVersion, AmqpVersion highestSupportedVersion)
            : base ($"Preferred version {preferedVersion} is not supported. Highest supported version is {highestSupportedVersion}")
        {
        }

        protected UnsupportedVersionException (SerializationInfo info, StreamingContext context)
            : base (info, context)
        {
        }
    }
}

