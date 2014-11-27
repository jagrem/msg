using Msg.Core.Transport.Connections;
using System.Threading.Tasks;
using NSubstitute;
using Msg.Core.Transport;

namespace Msg.Core.Specs.Transport.Connections
{
    public static class ConnectionFactoryExtensions
    {
        public static async Task<Connection> CreateReplayConnectionAsync (this ConnectionFactory factory)
        {
            return await Task.FromResult(Substitute.For<Connection> ());
        }
    }
}

