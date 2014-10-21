using Version = Msg.Domain.Version;
using Msg.Domain;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace Msg.Infrastructure
{
		
	public class AmqpSettingsBuilder
	{
		List<VersionRange> supportedVersions = new List<VersionRange>();
		IPAddress ipAddress = IPAddress.Any;
		int port = 1984;

		public AmqpSettingsBuilder SupportsVersion(byte major, byte minor, byte revision)
		{
			this.supportedVersions.Add (SupportedVersion.Exactly (major, minor, revision));
			return this;
		}

		public AmqpSettingsBuilder SupportsUpToVersion(byte major, byte minor, byte revision)
		{
			this.supportedVersions.Add (SupportedVersion.UpTo (major, minor, revision));
			return this;
		}

		public AmqpSettingsBuilder SupportsVersions(VersionRange versionRange)
		{
			this.supportedVersions.Add (versionRange);
			return this;
		}

		public AmqpSettingsBuilder WithIpAddress(string ip)
		{
			this.ipAddress = IPAddress.Parse (ip);
			return this;
		}

		public AmqpSettingsBuilder WithPort(int portNumber)
		{
			this.port = portNumber;
			return this;
		}

		public AmqpSettings Build()
		{
			return new AmqpSettings (
				this.supportedVersions.First().UpperBoundInclusive,
				this.supportedVersions, 
				this.ipAddress,
				this.port
			);
		}
	}
}
