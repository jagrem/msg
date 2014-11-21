using Msg.Core.Transport.Frames.Behaviour;

namespace Msg.Core.Transport.Frames
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class DispositionFrame : Frame
    {
        public DispositionFrame (Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
        {
        }
    }
}

