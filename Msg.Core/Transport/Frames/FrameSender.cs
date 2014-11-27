using System.Threading.Tasks;
using System;

namespace Msg.Core.Transport.Frames
{
    public static class FrameSender
    {
        public static async Task<FrameSendResult> SendFrame (IConnection connection, Frame frame)
        {
            try {
                await connection.SendAsync (frame.GetBytes ());
                return FrameSendResult.SendSucceeded ();
            } catch (Exception exception) {
                return FrameSendResult.SendFailed ();
            }
        }
    }
}

