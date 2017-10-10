using Xunit;
using FluentAssertions;
using Msg.Core.Transport.Connections;
using System.Threading.Tasks;
using System;
using Msg.Core.Transport.Connections.Tcp;
using Msg.Core.Transport;

namespace Msg.Core.Specs.Transport.Connections
{
    public class ConnectorSpecs
    {
        [Fact]
        public void When_closing_a_connection_fails_Then_it_should_throw ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var factory = new ConnectionFactory ();
            var connection = factory.CreateClosedConnection ();

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

