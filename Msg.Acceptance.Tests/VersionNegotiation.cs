using NUnit.Framework;
using Msg.Infrastructure;
using System.Threading.Tasks;
using Version = Msg.Core.Versioning.Version;
using Msg.Acceptance.Tests.TestDoubles;
using Msg.Infrastructure.Server;
using Msg.Core.Versioning;

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
			var serverSettings = new AmqpSettingsBuilder ().SupportsVersions (Version.From (0, 9, 0).To (1, 0, 0));
			new AmqpServer (serverSettings).Start();
			var clientSettings = new AmqpSettingsBuilder ().SupportsVersion (0, 9, 0);
			var client = new AmqpClient (clientSettings);

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version(0, 9, 0)));
		}

		[Test]
		public async Task Given_a_client_prefers_a_version_which_the_server_does_not_support_When_negotiating_which_version_to_use_Then_the_server_returns_its_preferred_version_And_closes_the_connection()
		{
			// Arrange
			var serverSettings = new AmqpSettingsBuilder ().SupportsVersions (Version.From (0, 9, 0).To (1, 0, 0));
			new AmqpServer (serverSettings).Start();
			var clientSettings = new AmqpSettingsBuilder ().SupportsVersion (0, 8, 0);
			var client = new AmqpClient (clientSettings);

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
			var serverSettings = new AmqpSettingsBuilder ().SupportsVersion (1, 0, 0);
			new AmqpServer (serverSettings).Start ();
			var clientSettings = new AmqpSettingsBuilder ().SupportsVersion (1, 0, 0);
			var client = new AmqpClient (clientSettings);

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version (1, 0, 0)));
		}

		[Test]
		public async Task Given_a_client_uses_a_higher_version_that_server_When_negotiating_which_version_to_use_Then_the_server_returns_the_highest_version_it_can_support()
		{
			// Arrange
			var serverSettings = new AmqpSettingsBuilder ().SupportsVersion (1, 0, 0);
			new AmqpServer (serverSettings).Start ();
			var clientSettings = new AmqpSettingsBuilder ().SupportsVersion (1, 0, 0);
			var client = new AmqpClient (clientSettings);

			// Act
			var result = await client.ConnectAsync ();

			// Assert
			Assert.That (result.AmqpVersion, Is.EqualTo (new Version (1, 0, 0)));
		}

		[Test]
		public async Task Given_the_client_sends_a_request_that_cannot_be_parsed_When_negotiating_which_version_to_use_Then_the_server_returns_its_preferred_version_And_closes_the_connection()
		{
			var settings = new AmqpSettingsBuilder ().SupportsVersion (1, 0, 0);
			new AmqpServer (settings).Start ();
			var client = new GarbageSpewingClient ();

			// Act
			Version result = await client.ConnectAsync ();

			// Assert
			Assert.That (result, Is.EqualTo (new Version (1, 0, 0)));
			Assert.That (client.IsConnected (), Is.False);
		}
	}
}

