using NUnit.Framework;
using FluentAssertions;
using System;
using System.Threading.Tasks;

namespace Msg.Acceptance.Tests
{
	[TestFixture]
	public class Connecting
	{
		[Test]
		public async Task Given_a_remote_broker_When_a_client_connects_to_the_broker_Then_a_connection_is_created()
		{
			using (new TestScope ()) {
				var subject = new AmqpClient ();
				var result = await subject.ConnectAsync ();
				result.Should ().BeAssignableTo<IAmqpConnection> ();
			}
		}
			
		[Test]
		public void Given_there_is_no_remote_broker_When_a_client_connects_to_the_broker_Then_an_exception_is_thrown()
		{
			var subject = new AmqpClient ();
			Func<Task> action = async () => await subject.ConnectAsync();
			action.ShouldThrow<AmqpConnectionAttemptFailedException> ();
		}
	}
}
