using System.Net;

namespace Msg.Infrastructure.Events
{
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

