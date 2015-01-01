using NUnit.Framework;
using System.Threading.Tasks;
using Msg.Core.Transport.Connections.Tcp;
using FluentAssertions;

namespace Msg.Core.Specs.Transport.Connections.Tcp
{
    [TestFixture]
    public class TcpConnectionSpecs
    {
        [Test]
        public async Task Given_a_Tcp_server_When_sending_bytes_Then_the_server_receives_the_bytes()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var server = new TcpServer ();
            await server.StartAsync ();
            var connection = new TcpConnection ();

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            await connection.SendAsync (new byte[] { 1, 2, 3, 4 });

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            var result = await server.GetReceivedBytes ();
            result.Should ().BeEquivalentTo (new byte[] { 1, 2, 3, 4 });
        }
    }
}
