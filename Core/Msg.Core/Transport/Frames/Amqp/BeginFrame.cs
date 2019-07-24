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

        public BeginFrame(
            ChannelId channelId,
            Option<ushort> remoteChannel,
            TransferNumber nextOutgoingId,
            uint incomingWindow,
            uint outgoingWindow,
            Option<Handle> handleMax,
            IReadOnlyList<Symbol> offeredCapabilities,
            IReadOnlyList<Symbol> desiredCapabilities)
            : base(channelId, PerformativeType.Begin)
        {
            remoteChannel = RemoteChannel;
            NextOutgoingId = nextOutgoingId;
            IncomingWindow = incomingWindow;
            OutgoingWindow = outgoingWindow;
            HandleMax = handleMax;
            OfferedCapabilities = offeredCapabilities;
            DesiredCapabilities = desiredCapabilities;
        }
    }
}

