using Version = Msg.Core.Transport.Version;
using System.Threading;

namespace Msg.Infrastructure.Server
{
	class AmqpServerContext
	{
		public AmqpServerContext(CancellationTokenSource cancellationTokenSource)
		{
			this.CancellationTokenSource = cancellationTokenSource;
		}

		public CancellationTokenSource CancellationTokenSource { get; private set; }

		public CancellationToken GetCancellationToken()
		{
			return this.CancellationTokenSource.Token;
		}
	}
}
