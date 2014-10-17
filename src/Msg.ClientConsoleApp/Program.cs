using Msg.Infrastructure;
using System.Threading.Tasks;
using Version = Msg.Domain.Version;
using Msg.Domain;

namespace Msg.ClientConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var client = new AmqpClient (SupportedVersion.Exactly(1, 0, 0));
			var t = Task.Factory.StartNew(async () => await client.ConnectAsync ());
			t.Wait ();
		}
	}
}
