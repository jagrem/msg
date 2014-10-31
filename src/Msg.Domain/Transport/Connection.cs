using System.Collections.Generic;

namespace Msg.Domain.Transport
{
	public class Connection : Endpoint
	{
		public long MaximumFrameSize { get; private set; }

		public IEnumerable<Session> Sessions { get; private set; }
	}
}

