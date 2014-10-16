using NUnit.Framework;
using Msg.Infrastructure;
using System.Threading.Tasks;
using Msg.Domain;
using Version = Msg.Domain.Version;

namespace Msg.Acceptance.Tests
{
	[TestFixture]
	public class VersionNegotiation
	{
		[Test]
		public async Task Given_a_client_uses_a_lower_version_than_server_When_negotiating_which_version_to_use_Then_the_server_returns_the_same_version_as_the_client()
		{
			// Arrange
			var server = new AmqpServer (Version.From(0, 9, 0).To(1, 0, 0));
			var clientVersion = Version.Exactly(0, 9, 0);
			var client = new AmqpClient (clientVersion);
			server.Start ();

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version(0, 9, 0)));
		}

		[Test]
		public async Task Given_a_client_uses_the_same_version_as_the_server_When_negotiating_which_version_to_user_Then_the_server_returns_the_same_version_as_the_client()
		{
			// Arrange
			var server = new AmqpServer (Version.Exactly (1, 0, 0));
			var client = new AmqpClient (Version.Exactly (1, 0, 0));
			server.Start ();

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version (1, 0, 0)));
		}

		[Test]
		public async Task Given_a_client_uses_a_higher_version_that_server_When_negotiating_which_version_to_use_Then_the_server_returns_the_highest_version_it_can_use()
		{
			// Arrange
			var server = new AmqpServer (Version.Exactly (1, 0, 0));
			var client = new AmqpClient (Version.Exactly (1, 0, 0));
			server.Start ();

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version (1, 0, 0)));
		}
	}
}

