using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Msg.Core.Transport;

namespace Msg.Core.Specs.Transport.Connections.Replay
{
    public class ReplayConnection : Connection
    {
        readonly Queue<Func<byte[],byte[]>> replays = new Queue<Func<byte[],byte[]>> ();

        int expectedNumberOfReplays = 0;

        internal ReplayConnection Record (Func<byte[], byte[]> replayFunction)
        {
            replays.Enqueue (replayFunction);
            return this;
        }

        internal void Replay()
        {
            expectedNumberOfReplays = replays.Count;
        }

        internal void Open ()
        {
            this.IsConnected = true;
            this.IsClosed = false;
        }

        internal void Close ()
        {
            this.IsClosed = true;
            this.IsConnected = false;
        }

        public override async Task<byte[]> SendAsync (byte[] message)
        {
            return await Task.FromResult (replays.Dequeue () (message));
        }
    }
}

