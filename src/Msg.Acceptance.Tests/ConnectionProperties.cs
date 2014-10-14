using NUnit.Framework;
using System.Threading.Tasks;
using FluentAssertions;
using Msg.Infrastructure;
using Version = Msg.Domain.Version;

namespace Msg.Acceptance.Tests
{
	[TestFixture]
	public class ConnectionProperties
	{
		[Test]
		public async Task Given_a_remote_broker_When_a_client_connects_Then_the_connection_has_AMQP_version_equal_to_broker_version ()
		{
			using (new TestScope ()) {
				var subject = new AmqpClient ();
				var result = await subject.ConnectAsync ();
				result.AmqpVersion.ShouldBeEquivalentTo (new Version (1, 0, 0));
			}
		}
	}
}

