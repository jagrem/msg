using Version = Msg.Domain.Version;

namespace Msg.Infrastructure
{

	public interface IAmqpConnection
	{
		Version AmqpVersion { get; }
	}
}
