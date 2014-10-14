using Msg.Infrastructure;
using Version = Msg.Domain.Version;

namespace Msg.Infrastructure
{

	public class AmqpTcpConnection : IAmqpConnection
	{
		public AmqpTcpConnection (Version amqpVersion)
		{
			this.AmqpVersion = amqpVersion;
		}

		public Version AmqpVersion { get; private set; }
	}
}
