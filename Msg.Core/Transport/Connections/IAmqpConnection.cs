using Version = Msg.Core.Versioning.Version;

namespace Msg.Core.Transport.Connections
{
	public interface IAmqpConnection
	{
		Version AmqpVersion { get; }

		bool IsConnected { get; }
	}
}
