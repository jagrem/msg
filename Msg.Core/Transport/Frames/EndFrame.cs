using Msg.Core.Transport.Frames.Behaviour;

namespace Msg.Core.Transport.Frames
{
    [InterceptedAtConnectionLevel]
    [HandledAtSessionLevel]
    public class EndFrame : Frame
    {
        public EndFrame (Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
        {
        }
    }
}

