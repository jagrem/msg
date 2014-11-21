using Msg.Core.Transport.Frames.Behaviour;

namespace Msg.Core.Transport.Frames
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class AttachFrame : Frame
    {
        public AttachFrame (Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
        {
        }
    }
}

