using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Msg.Core.Transport.Common.Versioning;
using Msg.Core.Transport.Common.Protocol;
using Msg.Core.Transport.Connections.Common;
using Msg.Core.Transport.Channels;

namespace Msg.Core.Transport
{
    public class Connection : Endpoint
    {
        internal Connection (ProtocolId protocol, AmqpVersion version, ITransportLayerConnection connection)
        {
            Protocol = protocol;
            Version = version;
        }

        public long MaximumFrameSize => 512L;
        public ProtocolId Protocol { get; }
        public AmqpVersion Version { get; }
        public IReadOnlyCollection<Channel> IncomingChannels { get; }
        public IReadOnlyCollection<Channel> OutgoingChannels { get; }
    }
}
