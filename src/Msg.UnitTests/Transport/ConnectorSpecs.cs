using NUnit.Framework;
using FluentAssertions;
using Msg.Domain.Transport.Connections;
using System.Threading.Tasks;
using Msg.Domain.Transport;

namespace Msg.UnitTests.Transport
{
	[TestFixture]
	public class ConnectorSpecs
	{
		[Test]
		public async Task When_opening_a_connection_Then_returns_an_open_connection()
		{
			var result = await Connector.OpenConnectionAsync ();
			result.IsConnected.Should ().BeTrue ();
		}
			
		[Test]
		public async Task When_closing_a_connection_Then_returns_a_closed_connection()
		{
			var connection = new Connection ();
			var result = await Connector.CloseConnectionAsync (connection);
			result.IsClosed.Should ().BeTrue ();
		}
	}
}

