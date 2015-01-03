using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System;
using Msg.Infrastructure;
using System.Linq;
using Msg.Infrastructure.Tcp;
using Msg.Core.Transport.Connections;

namespace Msg.Infrastructure
{
	public class AmqpClient
	{
		readonly AmqpSettings settings;

		public AmqpClient(AmqpSettingsBuilder settingsBuilder)
		{
			this.settings = settingsBuilder.Build ();
		}

		public async Task<IAmqpConnection> ConnectAsync ()
		{
			try {
				var client = new TcpClient ();
				await client.ConnectAsync (IPAddress.Loopback, 1984);
				var stream = client.GetStream ();
				var negotiatedVersion = await VersionNegotiator.NegotiateVersionWithServer (stream, this.settings.SupportedVersions.ToArray());
				return AmqpTcpConnection.CreateSuccessfulConnection (negotiatedVersion);
			} catch (Exception e) {
				throw new AmqpConnectionAttemptFailedException (e);
			}
		}
	}
}
