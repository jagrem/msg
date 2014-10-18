using Msg.Infrastructure;
using Version = Msg.Domain.Version;

namespace Msg.Infrastructure
{
	public class AmqpTcpConnection : IAmqpConnection
	{
		public AmqpTcpConnection (Version amqpVersion, bool isConnected)
		{
			this.AmqpVersion = amqpVersion;
			this.IsConnected = isConnected;
		}

		public Version AmqpVersion { get; private set; }

		public bool IsConnected { get; private set; }

		public static AmqpTcpConnection CreateSuccessfulConnection(Version amqpVersion)
		{
			return new AmqpTcpConnection (amqpVersion, isConnected: true);
		}

		public static AmqpTcpConnection CreateFailedConnection(Version amqpVersion)
		{
			return new AmqpTcpConnection (amqpVersion, isConnected: false);
		}
	}
}
