using System.Threading.Tasks;
using System;
using Version = Msg.Core.Versioning.Version;
using System.IO;
using Msg.Core.Versioning;
using System.Linq;

namespace Msg.Infrastructure
{
	public static class VersionNegotiator
	{
		public static async Task<Version> NegotiateVersionWithServer (Stream stream, VersionRange[] supportedVersions)
		{
			var clientVersion = supportedVersions.First ().UpperBoundInclusive;
			await stream.WriteVersionAsync (clientVersion);
			var serverVersion = await stream.ReadVersionAsync ();
			var negotiatedVersion = DecideWhichVersionToUse (clientVersion, serverVersion);
			return negotiatedVersion;
		}

		static Version DecideWhichVersionToUse (Version clientVersion, Version serverVersion)
		{
			if (serverVersion == clientVersion) {
				return clientVersion;
			} else if (serverVersion < clientVersion) {
				return serverVersion;
			} else {
				throw new NotSupportedException (string.Format ("AMQP version {0} is not supported.", serverVersion));
			}
		}
	}
}
