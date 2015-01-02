using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System;
using Msg.Core.Transport.Common;
using System.IO;
using System.Runtime.InteropServices;

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
