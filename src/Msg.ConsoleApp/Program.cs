using System;
using System.Net.Sockets;
using System.Net;
using System.IO;

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
				using(var writer = new StreamWriter(stream))
				{
					writer.Write ("tarzan");
				}
				client.Close ();
				Console.Write ("Closed connection"); 
			} finally {
				listener.Stop ();
			}
		}
	}
}
