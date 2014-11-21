using System.Threading.Tasks;
using Msg.Core.Transport.Connections.Tcp;
using Msg.Core.Transport.Connections.Http;
using Msg.Core.Transport.Connections.WebSockets;
using Msg.Core.Transport.Connections.Replay;

namespace Msg.Core.Transport.Connections
{
	public static class ConnectionFactory
	{
		public static async Task<Connection> CreateConnectionAsync()
		{
			/* defaults to TCP connection for the moment */
			return await CreateTcpConnectionAsync ();
		}

		public static async Task<TcpConnection> CreateTcpConnectionAsync()
		{
			// TODO: Replace with implementation to create raw TCP connection.
			await Task.Yield ();
			return new TcpConnection ();
		}

		public static async Task<HttpConnection> CreateHttpConnectionAsync()
		{
			// TODO: Replace with implementation to create wrapper for HTTP long-polling connection.
			await Task.Yield ();
			return new HttpConnection ();
		}

		public static async Task<WebSocketConnection> CreateWebSocketConnectionAsync()
		{
			// TODO: Replace with implementation to create WebSockets connection.
			await Task.Yield ();
			return new WebSocketConnection ();
		}

		public static async Task<ReplayConnection> CreateReplayConnectionAsync()
		{
			// TODO: Replace with implementation to create a replay connection for testing.
			await Task.Yield ();
			return new ReplayConnection ();
		}
	}
}

