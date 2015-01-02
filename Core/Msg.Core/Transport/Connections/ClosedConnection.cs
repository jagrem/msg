using System.Threading.Tasks;
using Msg.Core.Versioning;
using Msg.Core.Transport;

namespace Msg.Core.Transport.Connections
{

    public class ClosedConnection : IConnection
    {
        const string exceptionMessage = "The connection is closed.";

        internal ClosedConnection ()
        {
        }

        public Task<byte[]> SendAsync (byte[] message)
        {
            throw new System.InvalidOperationException (exceptionMessage);
        }

        public bool IsConnected {
            get {
                return false;
            }
        }

        public bool IsClosed {
            get {
                return true;
            }
        }

        public long MaximumFrameSize {
            get {
                throw new System.InvalidOperationException (exceptionMessage);
            }
        }

        public Version Version {
            get {
                throw new System.InvalidOperationException (exceptionMessage);
            }
        }

        public System.Collections.Generic.IEnumerable<VersionRange> SupportedVersions {
            get {
                throw new System.InvalidOperationException (exceptionMessage);
            }
        }
    }
}