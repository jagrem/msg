using System.Threading.Tasks;
using Version = Msg.Core.Versioning.Version;
using System;
using System.Net.Sockets;
using System.Net;

namespace Msg.Acceptance.Tests.TestDoubles
{
	class GarbageSpewingClient
	{
		TcpClient client;

		public async Task<byte[]> ConnectAsync() {
			client = new TcpClient ();
			await client.ConnectAsync (IPAddress.Loopback, 1984);
			var stream = client.GetStream ();
			await stream.WriteAsync (new byte[] { 1, 9, 8, 4 }, 0, 4);
			var buffer = new byte[8];
			await stream.ReadAsync (buffer, 0, 8);
			return buffer;
		}

		public bool IsConnected()
		{
			return client != null && client.Connected;
		}
	}
}
