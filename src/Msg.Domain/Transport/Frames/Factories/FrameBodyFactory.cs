using System.IO;
using System.Threading.Tasks;

namespace Msg.Domain.Transport.Frames.Factories
{

	static class FrameBodyFactory
	{
		public static async Task<FrameBody> GetFrameBodyFromBytes(byte[] frameBodyBytes)
		{
			using(var reader = new StreamReader(new MemoryStream(frameBodyBytes)))
			{
				await reader.ReadToEndAsync ();
			}

			return new FrameBody (null, null);
		}
	}
}
