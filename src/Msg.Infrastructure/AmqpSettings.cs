using Version = Msg.Domain.Version;
using Msg.Domain;
using System.Net;
using System.Collections.Generic;

namespace Msg.Infrastructure
{

	public class AmqpSettings
	{
		public AmqpSettings(Version preferredVersion, IEnumerable<VersionRange> supportedVersions, IPAddress ipAddress, int port)
		{
			this.PreferredVersion = preferredVersion;
			this.SupportedVersions = supportedVersions;
			this.IpAddress = ipAddress;
			this.Port = port;
		}

		public Version PreferredVersion { get; private set; }

		public IEnumerable<VersionRange> SupportedVersions { get; private set; }

		public IPAddress IpAddress { get; private set; }

		public int Port { get; private set; }
	}
}
