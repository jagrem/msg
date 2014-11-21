using Msg.Core.Transport.Connections;
using Msg.Core.Specs.Transport.Connections.Replay;

namespace Msg.Core.Specs.Transport.Connections
{
	public static class ConnectionFactoryExtensions
	{
		public static ReplayConnection CreateReplayConnectionAsync (this ConnectionFactory factory)
		{
			return new ReplayConnection ();
		}
	}
}

