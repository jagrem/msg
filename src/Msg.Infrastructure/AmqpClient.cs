using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System;
using Version = Msg.Domain.Version;
using Msg.Infrastructure;

namespace Msg.Infrastructure
{
	public class AmqpClient
	{
		public async Task<IAmqpConnection> ConnectAsync ()
		{
			try {
				var client = new TcpClient ();
				await client.ConnectAsync (IPAddress.Loopback, 1984);
				var stream = client.GetStream ();
				var buffer = new byte[8];
				await stream.ReadAsync (buffer, 0, 8);
				return new AmqpTcpConnection (buffer);
			} catch (Exception e) {
				throw new AmqpConnectionAttemptFailedException (e);
			}
		}
	}
}
