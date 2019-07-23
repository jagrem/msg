using Xunit;
using FluentAssertions;
using Msg.Core.Transport.Connections;
using System.Threading.Tasks;
using System;
using Msg.Core.Transport.Connections.Common;
using Msg.Core.Transport.Common.Protocol;
using Msg.Core.Transport.Common.Versioning;
using Msg.Core.Transport.Connections.Tcp;
using Msg.Core.Transport;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Msg.Core.Specs.Transport.Connections
{
    public class ConnectorSpecs
    {
        [Fact]
        public async Task Given_the_server_accepts_the_prefered_protocol_and_version_When_opening_a_connection_Then_the_connection_should_be_opened()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var transportLayerConnectionFactory = Substitute.For<ITransportLayerConnectionFactory>();
            var transportLayerConnection = Substitute.For<ITransportLayerConnection>();

            transportLayerConnectionFactory
                .OpenConnectionAsync()
                .Returns(Task.FromResult(transportLayerConnection));

            byte[] expectedProtocolHeaderBytes = new ProtocolHeader(ProtocolIds.AMQP, new AmqpVersion(1, 0, 0));

            transportLayerConnection
                .SendAsync(expectedProtocolHeaderBytes)
                .Returns(8L);

            transportLayerConnection
                .ReceiveAsync(8L)
                .Returns(expectedProtocolHeaderBytes);

            var subject = new Connector(transportLayerConnectionFactory);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = await subject.OpenConnectionAsync();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().BeOfType<Connection>();
        }

        [Fact]
        public void Given_the_server_does_not_support_the_preferred_version_When_opening_a_connection_Then_an_UnsupportedVersionException_is_thrown()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var transportLayerConnectionFactory = Substitute.For<ITransportLayerConnectionFactory>();
            var transportLayerConnection = Substitute.For<ITransportLayerConnection>();

            transportLayerConnectionFactory
                .OpenConnectionAsync()
                .Returns(Task.FromResult(transportLayerConnection));

            byte[] expectedProtocolHeaderBytes = new ProtocolHeader(ProtocolIds.AMQP, new AmqpVersion(1, 0, 0));

            transportLayerConnection
                .SendAsync(expectedProtocolHeaderBytes)
                .Returns(8L);

            byte[] actualProtocolHeaderBytes = new ProtocolHeader(ProtocolIds.AMQP, new AmqpVersion(0, 9, 0));

            transportLayerConnection
                .ReceiveAsync(8L)
                .Returns(actualProtocolHeaderBytes);

            var subject = new Connector(transportLayerConnectionFactory);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Func<Task> act = async () => await subject.OpenConnectionAsync();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act
                .Should().Throw<OpenConnectionFailedException>()
                .WithInnerException<UnsupportedVersionException>();
        }


        [Fact]
        public void Given_the_server_does_not_accept_the_prefered_protocol_When_opening_a_connection_Then_an_UnexpectedProtocolException_is_thrown()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var transportLayerConnectionFactory = Substitute.For<ITransportLayerConnectionFactory>();
            var transportLayerConnection = Substitute.For<ITransportLayerConnection>();

            transportLayerConnectionFactory
                .OpenConnectionAsync()
                .Returns(Task.FromResult(transportLayerConnection));

            byte[] preferedProtocolHeaderBytes = new ProtocolHeader(ProtocolIds.AMQP, new AmqpVersion(1, 0, 0));

            transportLayerConnection
                .SendAsync(preferedProtocolHeaderBytes)
                .Returns(8L);

            byte[] actualProtocolHeaderBytes = new ProtocolHeader((ProtocolId)2, new AmqpVersion(1, 0, 0));

            transportLayerConnection
                .ReceiveAsync(8L)
                .Returns(actualProtocolHeaderBytes);

            var subject = new Connector(transportLayerConnectionFactory);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Func<Task> act = async () => await subject.OpenConnectionAsync();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act
                .Should().Throw<OpenConnectionFailedException>()
                .WithInnerException<UnexpectedProtocolException>();
        }
    }
}

