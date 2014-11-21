using System.Collections.Generic;

namespace Msg.Core.Transport
{
    public class Container
    {
        public IEnumerable<Node> Nodes { get; private set; }
    }
}
