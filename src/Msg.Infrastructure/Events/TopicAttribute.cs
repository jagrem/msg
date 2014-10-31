using System;

namespace Msg.Infrastructure.Events
{
	[AttributeUsage(AttributeTargets.Class)]
	public class TopicAttribute : Attribute
	{
		public TopicAttribute (string topicName)
		{
			this.TopicName = topicName;
		}

		public string TopicName { get; private set; }
	}
}

