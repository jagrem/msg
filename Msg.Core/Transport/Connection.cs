using System.Collections.Generic;
using System.Linq;

namespace Msg.Core.Transport
{
	public class Connection : Endpoint, IConnection
	{
		public bool IsConnected { get; private set; }

		public bool IsClosed { get; private set; }

		public long MaximumFrameSize { get; private set; }

		public IEnumerable<Session> Sessions { get; private set; }

		public IEnumerable<Channel> IncomingChannels { get { return Sessions.Select (s => s.Receive); } }

		public IEnumerable<Channel> OutgoingChannels { get { return Sessions.Select (s => s.Send); } }
	}
}