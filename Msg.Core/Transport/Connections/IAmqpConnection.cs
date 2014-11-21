using Version = Msg.Core.Transport.Version;

namespace Msg.Core.Transport.Connections
{
	public interface IAmqpConnection
	{
		Version AmqpVersion { get; }

		bool IsConnected { get; }
	}
}
