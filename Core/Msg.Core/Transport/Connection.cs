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
        readonly ITransportLayerConnection _transportLayerConnection;
        readonly IEnumerable<Session> _sessions;
        readonly IEnumerable<IncomingChannel> _incomingChannels;
        readonly IEnumerable<OutgoingChannel> _outgoingChannels;

        internal Connection (ProtocolId protocol, AmqpVersion version, ITransportLayerConnection connection)
        {
            Protocol = protocol;
            Version = version;
            this._transportLayerConnection = connection;
        }

        public async Task<long> SendAsync (byte[] message) => await _transportLayerConnection.SendAsync (message);

        public async Task<byte []> ReceiveAsync (long count) => await _transportLayerConnection.ReceiveAsync(count);

        public long MaximumFrameSize => 512L;
        public ProtocolId Protocol { get; }
        public AmqpVersion Version { get; }

    }
}