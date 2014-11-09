using System.Threading.Tasks;

namespace Msg.Domain.Transport.Connections
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

