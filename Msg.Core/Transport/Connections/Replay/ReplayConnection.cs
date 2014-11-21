using System;
using System.Collections.Generic;
using Msg.Core.Transport.Frames;

namespace Msg.Core.Transport.Connections.Replay
{
	/* Replays test data */
	public class ReplayConnection : Connection
	{
		private readonly Queue<Func<byte[],byte[]>> replays = new Queue<Func<byte[],byte[]>> ();

		public ReplayConnection Replay(Func<byte[], byte[]> replayFunction)
		{
			replays.Enqueue (replayFunction);
			return this;
		}

		public ReplayExpectation Expect(Frame frame)
		{
			return new ReplayExpectation (this, frame);
		}

		public ReplayConnection Reply(Frame expectedFrame, Frame responseFrame)
		{
			replays.Enqueue (actualBytes =>  {
				var expectedBytes = expectedFrame.GetBytes ();

				if(expectedBytes != actualBytes)
				{
					throw new ReplayException(expectedBytes, actualBytes);
				}

				return responseFrame.GetBytes ();
			});
			return this;
		}

		public ReplayConnection ThrowException(Exception exception)
		{
			replays.Enqueue (message => { throw exception; });
			return this;
		}

		public ReplayConnection ThrowAnyException()
		{
			replays.Enqueue (message => { throw new Exception(); });
			return this;
		}
	}

	public class ReplayException : Exception
	{
		public ReplayException(byte[] expected, byte[] actual)
		{
			this.Actual = actual;
			this.Expected = expected;
		}

		public byte[] Expected { get; private set; }

		public byte[] Actual { get; private set; }
	}

	public class ReplayExpectation
	{
		readonly ReplayConnection connection;

		readonly Frame expectedFrame;

		public ReplayExpectation(ReplayConnection connection, Frame expectedFrame)
		{
			this.expectedFrame = expectedFrame;
			this.connection = connection;
		}

		public ReplayConnection ThenReplyWith(Frame frame)
		{
			return connection.Reply (expectedFrame, frame);
		}
	}
}

