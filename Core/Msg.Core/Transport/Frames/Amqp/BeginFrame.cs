using System.Collections.Generic;
using Msg.Core.Common;
using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;
using Msg.Core.Types;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtConnectionLevel]
    [HandledAtSessionLevel]
    public class BeginFrame : AmqpFrame
    {
        public Option<ushort> RemoteChannel { get; }
        public TransferNumber NextOutgoingId { get; }
        public uint IncomingWindow { get; }
        public uint OutgoingWindow { get; }
        public Option<Handle> HandleMax { get; }
        public IReadOnlyList<Symbol> OfferedCapabilities { get; }
        public IReadOnlyList<Symbol> DesiredCapabilities { get; }
        // public Fields Properties { get; }

        public BeginFrame(ChannelId channelId) : base(channelId, PerformativeType.Begin, new byte[0])
        {
        }
    }
}

