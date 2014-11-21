using System.Threading.Tasks;

namespace Msg.Core.Transport.Frames
{
	public static class FrameSender
	{
		public static async Task<FrameSendResult> SendFrame(Connection connection, Frame frame)
		{
			await connection.SendAsync (frame.GetBytes ());
			return FrameSendResult.SendSucceeded ();
		}
	}
}

