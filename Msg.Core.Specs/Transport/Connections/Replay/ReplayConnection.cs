using System;
using System.Collections.Generic;
using Msg.Core.Transport.Frames;
using System.Threading.Tasks;
using Msg.Core.Transport;

namespace Msg.Core.Specs.Transport.Connections.Replay
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

        public ReplayConnection AllowClientToConnect ()
        {
            this.Open ();
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

        public ReplayConnection AcknowledgeButDontClose (Frame expectedFrame)
        {
            Acknowledge (expectedFrame, false);
            return this;
        }

        void Open ()
        {
            this.IsConnected = true;
            this.IsClosed = false;
        }

        void Close ()
        {
            this.IsClosed = true;
            this.IsConnected = false;
        }

        void Acknowledge (Frame expectedFrame, bool shouldClose)
        {
            replays.Enqueue (actualBytes => {
                var expectedBytes = expectedFrame.GetBytes ();
                AssertAreEqual (expectedBytes, actualBytes);
                if (shouldClose)
                    Close ();
                return null;
            });
        }

        public ReplayConnection AcknowledgeAndClose (Frame expectedFrame)
        {
            Acknowledge (expectedFrame, true);
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
            return await Task.FromResult (replays.Dequeue () (message));
        }
    }
}

