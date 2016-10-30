using NUnit.Framework;
using FluentAssertions;
using Msg.Core.Transport.Connections;
using System.Threading.Tasks;
using System;
using Msg.Core.Transport.Connections.Tcp;
using Msg.Core.Transport;
using Msg.Core.Transport.Connections.Http;
using Msg.Core.Transport.Connections.WebSockets;

namespace Msg.Core.Specs.Transport.Connections
{
    [TestFixture]
    public class ConnectorSpecs
    {
        [Test]
        public void When_opening_a_connection_that_has_already_been_initialized_Then_it_should_throw ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var connection = new TcpConnection (null);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Func<Task> act = async () => await Connector.OpenConnectionAsync (connection);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<OpenConnectionFailedException> ()
               .WithInnerException<InvalidOperationException> ();
        }

        [Test]
        public void When_opening_a_connection_that_has_already_been_closed_Then_it_should_throw ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var connection = new ClosedConnection();

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Func<Task> act = async () => await Connector.OpenConnectionAsync (connection);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<OpenConnectionFailedException> ()
               .WithInnerException<InvalidOperationException> ();
        }

        [TestCase (typeof (UninitializedHttpConnection))]
        [TestCase (typeof (UninitializedWebSocketConnection))]
        public void When_opening_an_unsupported_connection_Then_it_should_throw (Type unsupportedConnection)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var connection = (IConnection)Activator.CreateInstance (unsupportedConnection);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Func<Task> act = async () => await Connector.OpenConnectionAsync (connection);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<OpenConnectionFailedException> ()
               .WithInnerException<NotSupportedException> ();
        }

        [Test]
        public async Task When_closing_a_connection_Then_it_should_return_a_closed_connection ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var factory = new ConnectionFactory ();
            var connection = factory.CreateOpenConnection ();

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

