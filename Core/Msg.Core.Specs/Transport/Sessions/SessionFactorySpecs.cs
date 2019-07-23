using Xunit;
using Msg.Core.Transport.Sessions;
using FluentAssertions;
using Msg.Core.Transport.Common.Protocol;
using Msg.Core.Transport.Common.Versioning;
using Msg.Core.Transport.Connections;
using Msg.Core.Transport.Connections.Common;
using NSubstitute;
using System.Threading.Tasks;

namespace Msg.Core.Specs.Transport.Sessions
{
    public class SessionFactorySpecs
    {
        [Fact]
        public async Task Given_a_connection_When_asked_for_a_session_Then_returns_a_different_session_each_time()
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

            var connection = await new Connector(transportLayerConnectionFactory).OpenConnectionAsync();
            var subject = new SessionFactory(connection);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result1 = subject.CreateSession();
            var result2 = subject.CreateSession();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result1.Should().NotBe(result2);
        }
    }
}

