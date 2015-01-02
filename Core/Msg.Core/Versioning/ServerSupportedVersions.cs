using System.Collections.ObjectModel;

namespace Msg.Core.Versioning
{
    public class ServerSupportedVersions : ReadOnlyCollection<VersionRange>
    {
        public ServerSupportedVersions(params VersionRange[] supportedVersions) : base(supportedVersions)
        {
        }
    }
}

