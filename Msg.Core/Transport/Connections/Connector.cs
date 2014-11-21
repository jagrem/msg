using Msg.Core.Transport.Frames;
using System.Threading.Tasks;
using Msg.Core.Transport.Frames.Factories;

namespace Msg.Core.Transport.Connections
{
	public static class Connector
	{
		public static async Task<IConnection> OpenConnectionAsync ()
		{
			var connection = await ConnectionFactory.CreateTcpConnectionAsync ();
			var openFrame = FrameFactory.CreateOpenFrame ();
			var result = await FrameSender.SendFrame (connection, openFrame);

			if(!result.SendWasSuccessful) {
				throw new OpenConnectionFailedException ();
			}

			return connection;
		}

		public static async Task<IConnection> CloseConnectionAsync (Connection connection)
		{
			var closeFrame = FrameFactory.CreateCloseFrame ();
			var result = await FrameSender.SendFrame(connection, closeFrame);

			if(!result.SendWasSuccessful) {
				throw new CloseConnectionFailedException ();
			}

			return connection;
		}
	}
}