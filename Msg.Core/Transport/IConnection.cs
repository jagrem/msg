using System.Threading.Tasks;

namespace Msg.Core.Transport
{
	public interface IConnection
	{
		bool IsConnected { get; }

		bool IsClosed { get; }

		long MaximumFrameSize { get; }

		Task<byte[]> SendAsync (byte[] message);
	}
}