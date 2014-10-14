using System;
using System.Net.Sockets;
using System.Net;

namespace Msg.ConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("msg");

			var listener = new TcpListener (new IPEndPoint (IPAddress.Loopback, 1984));

			try {
				listener.Start ();
				var client = listener.AcceptTcpClient ();
				Console.Write ("Connected");
				var stream = client.GetStream ();
				byte[] version = new Msg.Domain.Version(1, 0, 0);
				stream.Write (version, 0, version.Length);
				client.Close ();
				Console.Write ("Closed connection"); 
			} catch(Exception e) {
				Console.Write (e);
			} finally {
				listener.Stop ();
			}
		}
	}
}
