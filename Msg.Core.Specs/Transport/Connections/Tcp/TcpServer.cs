using System.Threading.Tasks;

namespace Msg.Core.Specs.Transport.Connections.Tcp
{
	public class TcpServer
	{
        public async Task StartAsync()
        {
            await Task.FromResult (0);
        }

        public byte[] GetReceivedBytes()
        {
            return new byte[0];
        }
	}
}

