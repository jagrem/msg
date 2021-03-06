using System;

namespace Msg.Core.Transport.Frames.Extensions
{
    public static class StringExtensions
    {
        public static bool HasFirstWord (this string content, string performative)
        {
            return content.StartsWith (performative, StringComparison.InvariantCulture);
        }
    }
}
