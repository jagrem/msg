using System.Collections.Generic;
using Msg.Core.Transport.Channels;

namespace Msg.Core.Transport
{
    public class Session : Endpoint
    {
        public string Name { get; private set; }

        public IEnumerable<Link> Links { get; private set; }

        public OutgoingChannel Send { get; private set; }

        public IncomingChannel Receive { get; private set; }
    }
}
