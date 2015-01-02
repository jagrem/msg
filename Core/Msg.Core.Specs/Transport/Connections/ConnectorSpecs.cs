using NUnit.Framework;
using FluentAssertions;
using Msg.Core.Transport.Connections;
using System.Threading.Tasks;
using Msg.Core.Transport;
using Version = Msg.Core.Versioning.Version;
using System;

namespace Msg.Core.Specs.Transport.Connections
{
    [TestFixture]
    public class ConnectorSpecs
    {
        [Test]
        public async Task When_opening_a_connection_Then_it_should_return_an_open_connection ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var factory = new ConnectionFactory ();
            var connection = await factory.CreateConnectionThatShouldOpenAsync ();

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = await Connector.OpenConnectionAsync (connection);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.IsConnected.Should ().BeTrue ();
        }

        [Test]
        public async Task When_opening_a_connection_fails_Then_it_should_throw ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var factory = new ConnectionFactory ();
            var connection = await factory.CreateClosedConnectionAsync ();

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Func<Task> act = async () => await Connector.OpenConnectionAsync (connection);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<OpenConnectionFailedException> ();
        }

        [Test]
        public async Task When_closing_a_connection_Then_it_should_return_a_closed_connection ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var factory = new ConnectionFactory ();
            var connection = await factory.CreateOpenConnectionAsync ();

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = await Connector.CloseConnectionAsync (connection);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.IsClosed.Should ().BeTrue ();
        }

        [Test]
        public async Task When_closing_a_connection_fails_Then_it_should_throw ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var factory = new ConnectionFactory ();
            var connection = await factory.CreateClosedConnectionAsync ();
           
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Func<Task> act = async () => await Connector.CloseConnectionAsync (connection);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<CloseConnectionFailedException> ();
        }
    }
}

