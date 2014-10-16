using System.Net.Sockets;
using System.Net;
using System;
using System.Threading.Tasks;
using Version = Msg.Domain.Version;
using System.Linq;
using Msg.Domain;

namespace Msg.Infrastructure
{
	public class AmqpServer 
	{
		readonly VersionRange[] supportedVersions;

		public AmqpServer(params VersionRange[] supportedVersions)
		{
			this.supportedVersions = supportedVersions;
		}

		public void Start ()
		{
			Task.Run (async () => await StartListeningAsync());
		}

		async Task StartListeningAsync()
		{
			var listener = new TcpListener (new IPEndPoint (IPAddress.Loopback, 1984));

			try {
				listener.Start ();
				var client = await listener.AcceptTcpClientAsync ();
				var stream = client.GetStream ();
				var version = await stream.ReadVersionAsync ();

				if(supportedVersions.Any(range => range.Contains(version)))
				{
					await stream.WriteVersionAsync (version);
				} else{
					await stream.WriteVersionAsync (supportedVersions.First().UpperBoundInclusive);
				}

				client.Close ();
			}
			catch (Exception e) {
				// Do nothing
			}
			finally {
				listener.Stop ();
			}
		}
	}
}

