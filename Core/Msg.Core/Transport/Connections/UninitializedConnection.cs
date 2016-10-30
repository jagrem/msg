using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Msg.Core.Versioning;

namespace Msg.Core.Transport.Connections
{
    public abstract class UninitializedConnection : IConnection
    {
        protected virtual string ExceptionMessageTemplate { get { return "Cannot call {0} on an uninitialized connection."; } }

        public bool IsClosed {
            get {
                throw GetnvalidOperationException ("IsClosed");
            }
        }

        public bool IsConnected {
            get {
                throw GetnvalidOperationException ("IsConnected");
            }
        }

        public long MaximumFrameSize {
            get {
                throw GetnvalidOperationException ("MaximumFrameSize");
            }
        }

        public IEnumerable<VersionRange> SupportedVersions {
            get {
                throw GetnvalidOperationException ("SupportedVersions");
            }
        }

        public Versioning.Version Version {
            get {
                throw GetnvalidOperationException ("Version");
            }
        }

        public Task<byte []> SendAsync (byte [] message)
        {
            throw GetnvalidOperationException ("SendAsync");
        }

        InvalidOperationException GetnvalidOperationException (string memberName)
        {
            return new InvalidOperationException (string.Format (CultureInfo.CurrentCulture, ExceptionMessageTemplate, memberName));
        }
    }
}
