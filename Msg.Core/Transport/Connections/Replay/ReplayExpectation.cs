using Msg.Core.Transport.Frames;

namespace Msg.Core.Transport.Connections.Replay
{
	/* Replays test data */
	public class ReplayExpectation
	{
		readonly ReplayConnection connection;

		readonly Frame expectedFrame;

		public ReplayExpectation (ReplayConnection connection, Frame expectedFrame)
		{
			this.expectedFrame = expectedFrame;
			this.connection = connection;
		}

		public ReplayConnection ThenReplyWith (Frame frame)
		{
			return connection.ReplyWithFrame (expectedFrame, frame);
		}

		public ReplayConnection ThenReplyWithNothing ()
		{
			return connection.Acknowledge (expectedFrame);
		}
	}
}
