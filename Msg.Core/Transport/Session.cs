using System.Collections.Generic;

namespace Msg.Core.Transport
{
    public class Session : Endpoint
    {
        public string Name { get; private set; }

        public IEnumerable<Link> Links { get; private set; }

        public Channel Send { get; private set; }

        public Channel Receive { get; private set; }
    }
}

