using System.Net.Sockets;
using System.Net;
using System;
using System.Threading.Tasks;
using Version = Msg.Core.Versioning.Version;
using Msg.Infrastructure.Events;
using Msg.Infrastructure.Server.Events;
using Msg.Infrastructure.Tcp.Events;
using Msg.Infrastructure.Server;

namespace Msg.Infrastructure.Tcp
{

	class AmqpTcpListener : IDisposable
	{
		TcpListener listener;

		readonly AmqpServerContext context;

		readonly AmqpSettings settings;

		public AmqpTcpListener(AmqpSettings settings, AmqpServerContext context)
		{
			this.settings = settings;
			this.context = context;

			try {
				this.listener = new TcpListener (new IPEndPoint (settings.IpAddress, settings.Port));
				listener.Start ();
				Event.Publish (new AmqpServerStarted(this.settings.IpAddress, this.settings.Port));
			} catch {
				Event.Publish (new AmqpServerFailedToStart(this.settings.IpAddress, this.settings.Port));
			}
		}

		public async Task AcceptTcpClientAsync(ClientRequestProcessor requestProcessor){
			while (listener.Pending ()) {
				var client = await listener.AcceptTcpClientAsync ();
				Event.Publish (new AmqpTcpClientConnected (client.Client.LocalEndPoint, client.Client.RemoteEndPoint));
				Task.Run (async () => await requestProcessor.ProcessClient (client), this.context.CancellationTokenSource.Token);
			}
		}
	
		public void Dispose ()
		{
			this.listener.Stop ();
			Event.Publish (new AmqpServerStopped());
		}
	}
}
