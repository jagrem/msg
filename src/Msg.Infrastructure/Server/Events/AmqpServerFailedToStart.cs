using System.Net;
using Msg.Infrastructure.Events;

namespace Msg.Infrastructure.Server.Events
{
	[Topic("events.server")]
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

