using System.IO;
using System.Threading.Tasks;
using System;

namespace Msg.Core.Transport.Frames.Factories
{
	public static class FrameBodyFactory
	{
		public static async Task<FrameBody> GetFrameBodyFromBytes(byte[] frameBodyBytes)
		{
			using(var reader = new StreamReader(new MemoryStream(frameBodyBytes)))
			{
				var content = await reader.ReadToEndAsync ();

				foreach(var performative in Performative.All){
					if(performative.ContainsTypeOf (content)){
						return performative.GetFrameBody (frameBodyBytes);
					}
				}

				throw new MalformedFrameException ("Unrecognised frame type.");
			}
		}
	}
}
