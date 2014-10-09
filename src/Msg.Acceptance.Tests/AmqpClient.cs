using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Msg.Acceptance.Tests
{
	public class AmqpClient
	{
		public async Task<IAmqpConnection> ConnectAsync ()
		{
			try
			{
				var client = new TcpClient ();
				await client.ConnectAsync (IPAddress.Loopback, 1984);
				var stream = client.GetStream ();
				string brokerName = "default";
				using(var reader = new StreamReader(stream))
				{
					var message = await reader.ReadLineAsync ();
					if(!string.IsNullOrEmpty (message)){
						brokerName = message;
					}
				}
				return new AmqpTcpConnection (brokerName);
			}
			catch(SocketException e) {
				throw new AmqpConnectionAttemptFailedException (e);
			}
		}
	}

	public class AmqpTcpConnection : IAmqpConnection
	{
		public AmqpTcpConnection(string brokerName)
		{
			this.BrokerName = brokerName;
		}

		public string BrokerName { get; private set; }
	}
}
