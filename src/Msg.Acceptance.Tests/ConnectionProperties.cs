using NUnit.Framework;
using System.Threading.Tasks;
using FluentAssertions;

namespace Msg.Acceptance.Tests
{
	[TestFixture]
	public class ConnectionProperties
	{
		[Test]
		public async Task Given_a_remote_broker_When_a_client_connects_Then_the_connection_has_broker_name_equal_to_remote_broker_name()
		{
			using (new TestScope ()) {
				var subject = new AmqpClient ();
				var result = await subject.ConnectAsync ();
				result.BrokerName.Should ().Be ("tarzan");
			}
		}
	}
}

