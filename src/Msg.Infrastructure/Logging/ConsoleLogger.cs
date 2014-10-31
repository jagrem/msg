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
			EventSubscriber.SubscribeTo ("events.server", WriteEvent);
			EventSubscriber.SubscribeTo ("events.tcp", WriteEvent);
		}

		void WriteEvent(IEvent @event)
		{
			Console.WriteLine (@event);
		}
	}
}

