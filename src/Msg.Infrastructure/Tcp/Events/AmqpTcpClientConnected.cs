using System.Net;
using Msg.Infrastructure.Events;

namespace Msg.Infrastructure.Tcp.Events
{
	[Topic("events.tcp")]
	public class AmqpTcpClientConnected : IEvent
	{
		public AmqpTcpClientConnected (EndPoint localEndpoint, EndPoint remoteEndpoint)
		{
			this.LocalEndpoint = localEndpoint;
			this.RemoteEndpoint = remoteEndpoint;
		}

		public EndPoint LocalEndpoint { get; private set; }

		public EndPoint RemoteEndpoint { get; private set; }
	}
}

