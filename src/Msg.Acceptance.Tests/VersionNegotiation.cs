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
		[Property("Issue","2")]
		public async Task Given_a_client_prefers_a_lower_version_than_the_version_the_server_prefers_When_negotiating_which_version_to_use_Then_the_server_returns_the_clients_preferred_version()
		{
			// Arrange
			new AmqpServer (SupportedVersion.From(0, 9, 0).To(1, 0, 0)).Start();
			var client = new AmqpClient (SupportedVersion.Exactly(0, 9, 0));

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version(0, 9, 0)));
		}

		[Test]
		public async Task Given_a_client_prefers_a_version_which_the_server_does_not_support_When_negotiating_which_version_to_use_Then_the_server_returns_its_preferred_version_And_closes_the_connection()
		{
			// Arrange
			new AmqpServer (SupportedVersion.From(0, 9, 0).To(1, 0, 0)).Start();
			var client = new AmqpClient (SupportedVersion.Exactly(0, 8, 0));

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version(1, 0, 0)));
			Assert.That (result.IsConnected, Is.False);
		}

		[Test]
		public async Task Given_a_client_prefers_the_same_version_as_the_server_When_negotiating_which_version_to_use_Then_the_server_returns_the_clients_preferred_version()
		{
			// Arrange
			new AmqpServer (SupportedVersion.Exactly (1, 0, 0)).Start ();
			var client = new AmqpClient (SupportedVersion.Exactly (1, 0, 0));

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version (1, 0, 0)));
		}

		[Test]
		public async Task Given_a_client_uses_a_higher_version_that_server_When_negotiating_which_version_to_use_Then_the_server_returns_the_highest_version_it_can_support()
		{
			// Arrange
			new AmqpServer (SupportedVersion.Exactly (1, 0, 0)).Start ();
			var client = new AmqpClient (SupportedVersion.Exactly (1, 0, 0));

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version (1, 0, 0)));
		}
	}
}

