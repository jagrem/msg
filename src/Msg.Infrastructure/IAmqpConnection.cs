using Version = Msg.Domain.Transport.Version;

namespace Msg.Infrastructure
{

	public interface IAmqpConnection
	{
		Version AmqpVersion { get; }

		bool IsConnected { get; }
	}
}
