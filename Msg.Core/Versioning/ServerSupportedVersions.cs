namespace Msg.Core.Versioning
{
    public class ServerSupportedVersions : SupportedVersions
    {
        public ServerSupportedVersions(params VersionRange[] supportedVersions) : base(supportedVersions)
        {
        }
    }
}

