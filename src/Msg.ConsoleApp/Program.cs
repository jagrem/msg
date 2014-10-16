using Msg.Infrastructure;
using Msg.Domain;

namespace Msg.ConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			new AmqpServer(Version.UpTo(1, 0, 0)).Start ();
		}
	}
}
