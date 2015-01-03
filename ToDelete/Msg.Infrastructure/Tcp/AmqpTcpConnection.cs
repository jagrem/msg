using Version = Msg.Core.Versioning.Version;
using Msg.Core.Transport.Connections;

namespace Msg.Infrastructure.Tcp
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
