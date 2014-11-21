using System;
using System.Threading.Tasks;
using Version = Msg.Core.Versioning.Version;
using System.Threading;
using Msg.Infrastructure.Tcp;

namespace Msg.Infrastructure.Server
{
	public class AmqpServer
	{
		readonly AmqpSettings settings;

		readonly AmqpServerContext context;

		public AmqpServer (AmqpSettingsBuilder settingsBuilder)
		{
			this.settings = settingsBuilder.Build ();
			this.context = new AmqpServerContext (new CancellationTokenSource ());
		}

		public void Start ()
		{
			Task.Run (async () => await StartAsync (), this.context.CancellationTokenSource.Token);
		}

		public async Task StartAsync ()
		{
			try {
				using (var listener = new AmqpTcpListener (this.settings, this.context)) {
					while (!this.context.CancellationTokenSource.Token.IsCancellationRequested) {
						await listener.AcceptTcpClientAsync (new ClientRequestProcessor (settings));
					}
				}
			} catch (Exception e) {
				if (!this.context.CancellationTokenSource.IsCancellationRequested) {
					this.context.CancellationTokenSource.Cancel ();
				}
			}
		}

		public void Stop ()
		{
			this.context.CancellationTokenSource.Cancel ();
		}
	}	
}

