using Msg.Core.Transport.Connections;
using Msg.Core.Specs.Transport.Connections.Replay;
using System.Threading.Tasks;

namespace Msg.Core.Specs.Transport.Connections
{
    public static class ConnectionFactoryExtensions
    {
        public static async Task<ReplayConnection> CreateReplayConnectionAsync (this ConnectionFactory factory)
        {
            return await Task.FromResult(new ReplayConnection ());
        }
    }
}

