using System.Threading.Tasks;

namespace Msg.Core.Transport.Connections.WebSockets
{
	public class WebSocketConnection : Connection
	{
		public override Task<byte[]> SendAsync (byte[] message)
		{
			throw new System.NotImplementedException ();
		}
	}
}

