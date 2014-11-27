using Version = Msg.Core.Versioning.Version;
using Msg.Core.Versioning;
using System.Linq;

namespace Msg.Core.Transport
{
    public static class ConnectionExtensions
    {
        public static void UseVersion (this IConnection connection, Version version)
        {
            connection.Version = version;
        }

        public static void Supports (this IConnection connection, VersionRange versions)
        {
            var supportedVersions = connection.SupportedVersions.ToList ();
            supportedVersions.Add (versions);
            connection.SupportedVersions = supportedVersions;
        }
    }
}