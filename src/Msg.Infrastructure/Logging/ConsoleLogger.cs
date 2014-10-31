using Msg.Infrastructure.Events;
using System;

namespace Msg.Infrastructure.Logging
{
	public class ConsoleLogger
	{
		public static ConsoleLogger Create()
		{
			return new ConsoleLogger ();
		}

		ConsoleLogger()
		{
			EventSubscriber.SubscribeTo ("Debug", WriteEvent);
		}

		void WriteEvent(IEvent @event)
		{
			Console.WriteLine (@event);
		}
	}
}

