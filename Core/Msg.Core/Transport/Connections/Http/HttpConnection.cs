using System.Threading.Tasks;

namespace Msg.Core.Transport.Connections.Http
{
    public class HttpConnection : Connection, IHttpConnection
    {
        public override Task<byte[]> SendAsync (byte[] message)
        {
            throw new System.NotImplementedException ();
        }
    }
}

