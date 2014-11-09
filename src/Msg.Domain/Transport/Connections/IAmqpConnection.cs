using Version = Msg.Domain.Transport.Version;

namespace Msg.Domain.Transport.Connections
{

	public interface IAmqpConnection
	{
		Version AmqpVersion { get; }

		bool IsConnected { get; }
	}
}
