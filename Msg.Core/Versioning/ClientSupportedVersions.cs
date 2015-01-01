namespace Msg.Core.Versioning
{
    public class ClientSupportedVersions : SupportedVersions
    {
        public ClientSupportedVersions(params VersionRange[] supportedVersions) : base(supportedVersions)
        {
        }
    }
}

