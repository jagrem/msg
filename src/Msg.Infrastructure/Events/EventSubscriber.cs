using System;
using System.Collections.Generic;

namespace Msg.Infrastructure.Events
{
	public static class EventSubscriber
	{
		private static readonly IDictionary<string,IList<Action<IEvent>>> subscriptions = new Dictionary<string, IList<Action<IEvent>>>();

		public static void SubscribeTo(string topic, Action<IEvent> action)
		{
			if (!subscriptions.ContainsKey (topic)) {
				subscriptions.Add (topic, new List<Action<IEvent>> ());
			}

			subscriptions [topic].Add (action);
		}

		public static IList<Action<IEvent>> GetSubscribersFor(Type eventType)
		{
			if (!typeof(IEvent).IsAssignableFrom (eventType)) {
				throw new ArgumentException ("Event type must implement IEvent.", "eventType");
			}

			var topic = (TopicAttribute) Attribute.GetCustomAttribute (eventType, typeof(TopicAttribute));
			var topicName = topic.TopicName;

			if (!subscriptions.ContainsKey (topicName)) {
				return new List<Action<IEvent>> ();
			}

			return subscriptions [topicName];
		}
	}
}

