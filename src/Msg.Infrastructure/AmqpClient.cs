using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System;
using Msg.Infrastructure;
using Msg.Domain;

namespace Msg.Infrastructure
{
	public class AmqpClient
	{
		readonly VersionRange[] supportedVersions;

		public AmqpClient(params VersionRange[] supportedVersions)
		{
			Array.Sort (supportedVersions);
			this.supportedVersions = supportedVersions;
		}

		public async Task<IAmqpConnection> ConnectAsync ()
		{
			try {
				var client = new TcpClient ();
				await client.ConnectAsync (IPAddress.Loopback, 1984);
				var stream = client.GetStream ();
				var negotiatedVersion = await VersionNegotiator.NegotiateVersionWithServer (stream, supportedVersions);
				return AmqpTcpConnection.CreateSuccessfulConnection (negotiatedVersion);
			} catch (Exception e) {
				throw new AmqpConnectionAttemptFailedException (e);
			}
		}
	}
}
