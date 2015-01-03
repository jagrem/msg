using System.Collections.Generic;

namespace Msg.Core.Peers
{
    public abstract class Container
    {
        public IEnumerable<Node> Nodes { get; private set; }

        public abstract void Start ();

        public abstract void Stop ();
    }
}
