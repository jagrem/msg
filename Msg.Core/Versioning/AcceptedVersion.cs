namespace Msg.Core.Versioning
{
    public class AcceptedVersion : Version
    {
        public AcceptedVersion (Version version) : base(version.Major, version.Minor, version.Revision)
        {
        }
    }
}

