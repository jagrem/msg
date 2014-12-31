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
            // Run a TCP server on a different thread
            var server = new TcpServer ();

            // Once the server is ready start the test, use a manual reset or similar
            await server.StartAsync ();

            // Create a connection and connect to the server
            var connection = new TcpConnection ();

            // Send bytes via the connection
            await connection.SendAsync (new byte[] { 1, 2, 3, 4 });

            // Close the connection

            // Check that the bytes were received
            var result = server.GetReceivedBytes ();
            result.Should ().BeEquivalentTo (new byte[] { 1, 2, 3, 4 });
        }
    }
}

