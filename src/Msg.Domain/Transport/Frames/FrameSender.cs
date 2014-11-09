using System.Threading.Tasks;

namespace Msg.Domain.Transport.Frames
{
	public static class FrameSender
	{
		public static async Task<FrameSendResult> SendFrame(Connection connection, Frame frame)
		{
			await Task.Yield ();
			return FrameSendResult.SendSucceeded ();
		}
	}
}

