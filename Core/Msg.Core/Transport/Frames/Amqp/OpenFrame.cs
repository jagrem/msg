using System.Collections.Generic;
using Msg.Core.Common;
using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;
using Msg.Core.Types;

namespace Msg.Core.Transport.Frames.Amqp
{
    [HandledAtConnectionlevel]
    public class OpenFrame : AmqpFrame
    {
        public string ContainerId { get; }
        public Option<string> Hostname { get; }
        public Option<uint> MaxFrameSize { get; }
        public Option<ushort> ChannelMax { get; }
        public Option<Millisecond> IdleTimeOut { get; }
        public IReadOnlyList<IETFLanguageTag> OutgoingLocales { get; }
        public IReadOnlyList<IETFLanguageTag> IncomingLocales { get; }
        public IReadOnlyList<Symbol> OfferedCapabilities { get; }
        public IReadOnlyList<Symbol> DesiredCapabilities { get; }
        // public Fields Properties { get; }

        public OpenFrame(ChannelId channelId) : base(channelId, PerformativeType.Open, new byte[0])
        {
        }
    }
}

