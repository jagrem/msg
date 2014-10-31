using System.Net;

namespace Msg.Infrastructure.Events
{
	[Topic("Debug")]
	public class AmqpServerStarted : IEvent
	{
		public AmqpServerStarted (IPAddress ipAddress, int port)
		{
			this.IpAddress = ipAddress;
			this.Port = port;
		}

		public IPAddress IpAddress { get; private set; }

		public int Port { get; private set; }
	}
}

