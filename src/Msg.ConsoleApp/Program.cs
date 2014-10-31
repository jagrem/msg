using Msg.Infrastructure;
using System;
using Msg.Infrastructure.Logging;

namespace Msg.ConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			ConsoleLogger.Create ();
			var settingsBuilder = new AmqpSettingsBuilder ()
				.WithPort (1984)
				.SupportsVersion (1, 0, 0);
			var server = new AmqpServer(settingsBuilder);
			Console.WriteLine ("MSG version 0.0.1 DEV");
			server.Start ();
			Console.WriteLine ("Started server.");
			Console.WriteLine ("Press enter to stop...");
			Console.ReadLine ();
			server.Stop ();
			Console.WriteLine ("Server stopped.");
		}
	}
}
