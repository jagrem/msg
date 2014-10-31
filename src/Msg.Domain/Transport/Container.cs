using System.Collections.Generic;

namespace Msg.Domain.Transport
{
	public class Container
	{
		public IEnumerable<Node> Nodes { get; private set; }
	}
}

