using System;

namespace Msg.Core.Transport
{
	public class Link : Endpoint
	{
		public string Name { get; private set; }

		public Node Source { get; private set; }

		public Node Target { get; private set; }

		public TimeSpan Timeout { get; private set; }
	}
}

