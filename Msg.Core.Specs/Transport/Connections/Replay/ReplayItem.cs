using System;

namespace Msg.Core.Specs.Transport.Connections.Replay
{
    class ReplayItem
    {
        readonly Func<ReplayContext,ReplayResult> function;

        public ReplayItem(Func<ReplayContext,ReplayResult> function)
        {
            this.function = function;
        }

        public ReplayResult Replay(ReplayContext context)
        {
            return function (context);
        }

        public bool IsEmpty()
        {
            return this.function == null;
        }

        public static ReplayItem Empty()
        {
            return new ReplayItem (null);
        }
    }
}
