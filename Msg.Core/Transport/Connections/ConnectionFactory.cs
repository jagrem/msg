using System.Threading.Tasks;

namespace Msg.Core.Transport.Connections
{
	public static class ConnectionFactory
	{
		public static async Task<Connection> CreateTcpConnectionAsync()
		{
			Task.Yield ();
			return new Connection ();
		}
	}
}

