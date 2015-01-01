using System.Collections.ObjectModel;

namespace Msg.Core.Versioning
{
    public class SupportedVersions : ReadOnlyCollection<VersionRange>
    {
        public SupportedVersions (params VersionRange[] supportedVersions) : base(supportedVersions)
        {
        }
    }
}

