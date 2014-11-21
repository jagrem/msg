using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Msg.Core.Transport
{
	public abstract class Connection : Endpoint, IConnection
	{
		public bool IsConnected { get; protected set; }

		public bool IsClosed { get; protected set; }

		public long MaximumFrameSize { get; protected set; }

		public IEnumerable<Session> Sessions { get; protected set; }

		public IEnumerable<Channel> IncomingChannels { get { return Sessions.Select (s => s.Receive); } }

		public IEnumerable<Channel> OutgoingChannels { get { return Sessions.Select (s => s.Send); } }

		public abstract Task<byte[]> SendAsync (byte[] message);
	}
}