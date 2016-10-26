using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Version = Msg.Core.Versioning.Version;
using Msg.Core.Versioning;
using Msg.Core.Transport.Channels;

namespace Msg.Core.Transport
{
    public abstract class Connection : Endpoint, IConnection
    {
        protected Connection ()
        {
            SupportedVersions = new List<VersionRange> ();
        }

        public Version Version { get; internal set; }

        public IEnumerable<VersionRange> SupportedVersions { get; internal set; }

        public bool IsConnected { get; protected set; }

        public bool IsClosed { get; protected set; }

        public long MaximumFrameSize { get; protected set; }

        public IEnumerable<Session> Sessions { get; protected set; }

        public IEnumerable<IncomingChannel> IncomingChannels { get { return Enumerable.Empty<IncomingChannel> (); } }

        public IEnumerable<OutgoingChannel> OutgoingChannels { get { return Enumerable.Empty<OutgoingChannel> (); } }

        public abstract Task<byte[]> SendAsync (byte[] message);
    }
}