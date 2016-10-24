using System.Threading.Tasks;
using Msg.Core.Versioning;
using Msg.Core.Transport;

namespace Msg.Core.Transport.Connections
{
    public class OpenConnection : IConnection
    {
        readonly IConnection connection;

        internal OpenConnection (IConnection connection)
        {
            this.connection = connection;
        }

        public Task<byte[]> SendAsync (byte[] message)
        {
            return connection.SendAsync (message);
        }

        public bool IsConnected {
            get {
                return true;
            }
        }

        public bool IsClosed {
            get {
                return false;
            }
        }

        public long MaximumFrameSize {
            get {
                // Replace with negotiated maximum frame size
                return connection.MaximumFrameSize;
            }
        }

        public Version Version {
            get {
                // Replace with version parameter
                return connection.Version;
            }
        }

        public System.Collections.Generic.IEnumerable<VersionRange> SupportedVersions {
            get {
                return connection.SupportedVersions;
            }
        }
    }
}