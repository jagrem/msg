using System.Threading.Tasks;
using System.IO;

namespace Msg.Core.Specs.Transport.Connections.Tcp
{

    static class DataStreamReader
    {
        const int ReadBufferSize = 4;

        public static async Task<byte[]> ReadDataAsync (Stream stream)
        {
            var buffer = new byte[ReadBufferSize];
            await stream.ReadAsync (buffer, 0, buffer.Length);
            return buffer;
        }
    }
}
