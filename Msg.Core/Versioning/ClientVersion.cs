namespace Msg.Core.Versioning
{
    public class ClientVersion : Version
    {
        public ClientVersion(byte major, byte minor, byte revision) : base(major, minor, revision)
        {
        }
    }
}

