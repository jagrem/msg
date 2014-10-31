using System.Linq;

namespace Msg.Infrastructure.Events
{
	public static class Event
	{
		public static void Publish(IEvent @event)
		{
			var subscribers = EventSubscriber.GetSubscribersFor (@event.GetType ());
			subscribers.ToList ().ForEach (subscriber => subscriber (@event));
		}
	}
}

