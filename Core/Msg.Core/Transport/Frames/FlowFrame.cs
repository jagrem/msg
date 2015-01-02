using Msg.Core.Transport.Frames.Behaviour;

namespace Msg.Core.Transport.Frames
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class FlowFrame : Frame
    {
        public FlowFrame (Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
        {
        }
    }
}

