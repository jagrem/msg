namespace Msg.Core.Versioning
{
    public class ServerVersion : Version
    {
        public ServerVersion(Version version) : base(version.Major, version.Minor, version.Revision)
        {
        }
    }
}

