using System.Net.Sockets;
using System.Threading.Tasks;
using Version = Msg.Core.Versioning.Version;
using System.Linq;

namespace Msg.Infrastructure.Server
{
	class ClientRequestProcessor
	{
		readonly AmqpSettings settings;

		public ClientRequestProcessor (AmqpSettings settings)
		{
			this.settings = settings;
		}

		public async Task ProcessClient (TcpClient client)
		{
			var stream = client.GetStream ();
			try {
				var version = await stream.ReadVersionAsync ();
				if (IsVersionSupported (version)) {
					await stream.WriteVersionAsync (version);
				} else {
					await stream.WriteVersionAsync (this.settings.PreferredVersion);
				}
			} catch {
				await stream.WriteVersionAsync (this.settings.PreferredVersion);
			} finally {
				if (client.Connected) {
					client.Close ();
				}
			}
		}

		bool IsVersionSupported (Version version)
		{
			return this.settings.SupportedVersions.Any (range => range.Contains (version));
		}
	}
}
