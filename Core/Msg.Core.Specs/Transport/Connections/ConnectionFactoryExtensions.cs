using Msg.Core.Transport.Connections;
using System.Threading.Tasks;
using NSubstitute;
using Msg.Core.Transport;
using System;

namespace Msg.Core.Specs.Transport.Connections
{
    public static class ConnectionFactoryExtensions
    {
        public static IConnection CreateConnectionThatShouldOpen (this ConnectionFactory factory)
        {
            return Substitute.For<Connection> ();
        }

        public static IConnection CreateClosedConnection (this ConnectionFactory factory)
        {
            return new ClosedConnection ();
        }

        public static IConnection CreateOpenConnection(this ConnectionFactory factory)
        {
            var connection = Substitute.For<IConnection> ();
            return new OpenConnection(connection);
        }

        public static async Task<Connection> CreateOpenConnectionThatShouldThrowAsync(this ConnectionFactory factory, Exception exception)
        {
            var connection = Substitute.For<Connection> ();
            return await Task.FromResult (connection);
        }
    }
}

