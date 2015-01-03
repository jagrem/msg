namespace Msg.Core.Versioning
{
    public static class ClientVersionExtensions
    {
        public static bool IsNotMalformed(this ClientVersion version)
        {
            return !(version is MalformedClientVersion);
        }
    }
}

