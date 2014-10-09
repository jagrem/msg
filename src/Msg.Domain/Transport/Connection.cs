using System.Collections.Generic;

namespace Msg.Domain
{
	public class Connection : Endpoint
	{
		public long MaximumFrameSize { get; private set; }

		public IEnumerable<Session> Sessions { get; private set; }
	}
}

