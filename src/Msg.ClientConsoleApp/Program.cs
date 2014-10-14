using Msg.Infrastructure;
using System.Threading.Tasks;
using System;

namespace Msg.ClientConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var client = new AmqpClient ();
			var t = Task.Factory.StartNew(async () => await client.ConnectAsync ());
			t.Wait ();
		}
	}
}
