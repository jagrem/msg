using NUnit.Framework;
using System.Runtime.Remoting.Contexts;

namespace Msg.Core.Specs.Transport.Connections.Replay
{

    class ReplayResult
    {
        public ReplayContext Context { get; set; }

        public static ReplayResult Success()
        {
            return new ReplayResult ();
        }

        public static ReplayResult From(byte[] message)
        {
            return new ReplayResult { Context = new ReplayContext { Message = message } };
        }
    }
    
}
