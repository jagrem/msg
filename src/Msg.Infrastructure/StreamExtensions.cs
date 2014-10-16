using System.Net.Sockets;
using System.Net;
using System;
using System.Threading.Tasks;
using Version = Msg.Domain.Version;
using System.Linq;
using System.IO;

namespace Msg.Infrastructure
{

	static class StreamExtensions
	{
		public static async Task<Version> ReadVersionAsync(this Stream stream)
		{
			var buffer = new byte[8];
			await stream.ReadAsync (buffer, 0, buffer.Length);
			return (Version)buffer;
		}

		public static async Task WriteVersionAsync(this Stream stream, Version version)
		{
			await stream.WriteAsync (version, 0, 8);
		}
	}
}
