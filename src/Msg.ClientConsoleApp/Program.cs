using Msg.Infrastructure;
using System.Threading.Tasks;
using Version = Msg.Domain.Version;

namespace Msg.ClientConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var settings = new AmqpSettingsBuilder ().SupportsVersion (1, 0, 0);
				var client = new AmqpClient (settings);
			var t = Task.Factory.StartNew(async () => await client.ConnectAsync ());
			t.Wait ();
		}
	}
}
