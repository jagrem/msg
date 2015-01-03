using Msg.Infrastructure.Events;

namespace Msg.Infrastructure.Server.Events
{
	[Topic("events.server")]
	public class AmqpServerStopped : IEvent
	{
	}
}

