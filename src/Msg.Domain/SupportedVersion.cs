namespace Msg.Domain
{
	public static class SupportedVersion
	{
		public static VersionRange From(byte major, byte minor, byte revision)
		{
			return new VersionRange (new Version(major, minor, revision), Version.Any);
		}

		public static VersionRange UpTo(byte major, byte minor, byte revision)
		{
			return new VersionRange (Version.Any, new Version(major, minor, revision));
		}

		public static VersionRange Exactly(byte major, byte minor, byte revision)
		{
			return new VersionRange (new Version(major, minor, revision), new Version(major, minor, revision));
		}
	}
}

