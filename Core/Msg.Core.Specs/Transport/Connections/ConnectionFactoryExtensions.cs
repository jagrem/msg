using Msg.Core.Transport.Connections;
using System.Threading.Tasks;
using NSubstitute;
using Msg.Core.Transport;
using System;

namespace Msg.Core.Specs.Transport.Connections
{
    public static class ConnectionFactoryExtensions
    {
        public static async Task<Connection> CreateConnectionThatShouldOpenAsync (this ConnectionFactory factory)
        {
            return await Task.FromResult(Substitute.For<Connection> ());
        }

        public static async Task<IConnection> CreateClosedConnectionAsync (this ConnectionFactory factory)
        {
            var connection = Substitute.For<Connection> ();
            return await Task.FromResult (new ClosedConnection ());
        }

        public static async Task<IConnection> CreateOpenConnectionAsync(this ConnectionFactory factory)
        {
            var connection = Substitute.For<Connection> ();
            return await Task.FromResult (new OpenConnection(connection));
        }

        public static async Task<Connection> CreateOpenConnectionThatShouldThrowAsync(this ConnectionFactory factory, Exception exception)
        {
            var connection = Substitute.For<Connection> ();
            return await Task.FromResult (connection);
        }
    }
}

