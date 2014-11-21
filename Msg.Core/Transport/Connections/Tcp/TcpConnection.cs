using System.Threading.Tasks;

namespace Msg.Core.Transport.Connections.Tcp
{
	public class TcpConnection : Connection
	{
		public override Task<byte[]> SendAsync (byte[] message)
		{
			throw new System.NotImplementedException ();
		}
	}
}

