using System;
using System.Collections.Generic;
using Msg.Core.Transport.Frames;
using System.Threading.Tasks;

namespace Msg.Core.Transport.Connections.Replay
{
	/* Replays test data */
	public class ReplayConnection : Connection
	{
		private readonly Queue<Func<byte[],byte[]>> replays = new Queue<Func<byte[],byte[]>> ();

		public ReplayConnection Replay (Func<byte[], byte[]> replayFunction)
		{
			replays.Enqueue (replayFunction);
			return this;
		}

		public ReplayExpectation Expect (Frame frame)
		{
			return new ReplayExpectation (this, frame);
		}

		public ReplayConnection ReplyWithFrame (Frame expectedFrame, Frame responseFrame)
		{
			replays.Enqueue (actualBytes => {
				var expectedBytes = expectedFrame.GetBytes ();
				AssertAreEqual (expectedBytes, actualBytes);
				return responseFrame.GetBytes ();
			});
			return this;
		}

		public ReplayConnection Acknowledge (Frame expectedFrame)
		{
			replays.Enqueue (actualBytes => {
				var expectedBytes = expectedFrame.GetBytes ();
				AssertAreEqual (expectedBytes, actualBytes);
				return null;
			});
			return this;
		}

		static void AssertAreEqual (byte[] expected, byte[] actual)
		{
			if (expected.Length != actual.Length) {
				throw new ReplayException (expected, actual);
			}

			for (int i = 0; i < expected.Length; i++) {
				if (expected [i] != actual [i]) {
					throw new ReplayException (expected, actual);
				}
			}
		}

		public ReplayConnection ThrowException (Exception exception)
		{
			replays.Enqueue (message => {
				throw exception;
			});
			return this;
		}

		public ReplayConnection ThrowAnyException ()
		{
			replays.Enqueue (message => {
				throw new Exception ();
			});
			return this;
		}

		public override async Task<byte[]> SendAsync (byte[] message)
		{
			if (replays.Count == 1) {
				this.IsClosed = true;
				this.IsConnected = false;
			}

			return await Task.FromResult (replays.Dequeue () (message));
		}
	}
}

