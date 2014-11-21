using NUnit.Framework;
using FluentAssertions;
using Msg.Core.Transport.Connections;
using System.Threading.Tasks;
using Msg.Core.Transport;
using Msg.Core.Transport.Connections.Replay;
using Msg.Core.Transport.Frames.Factories;

namespace Msg.Core.Specs.Transport
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
			//-----------------------------------------------------------------------------------------------------------
			// Arrange
			//-----------------------------------------------------------------------------------------------------------
			var connection = new ReplayConnection ()
					.Expect (FrameFactory.CreateCloseFrame ())
					.ThenReplyWithNothing ();

			//-----------------------------------------------------------------------------------------------------------
			// Act
			//-----------------------------------------------------------------------------------------------------------
			var result = await Connector.CloseConnectionAsync (connection);

			//-----------------------------------------------------------------------------------------------------------
			// Assert
			//-----------------------------------------------------------------------------------------------------------
			result.IsClosed.Should ().BeTrue ();
		}
	}
}

