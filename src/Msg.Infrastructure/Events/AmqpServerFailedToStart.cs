using System.Net;

namespace Msg.Infrastructure
{
	public class AmqpServerFailedToStart : IEvent
	{
		public AmqpServerFailedToStart (IPAddress ipAddress, int port)
		{
			this.IpAddress = ipAddress;
			this.Port = port;
		}

		public IPAddress IpAddress { get; private set; }

		public int Port { get; private set; }
	}
}

