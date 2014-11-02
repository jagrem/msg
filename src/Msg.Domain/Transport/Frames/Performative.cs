using System;
using Msg.Domain.Transport.Frames.Constants;
using System.Collections.Generic;
using Msg.Domain.Transport.Frames.Extensions;

namespace Msg.Domain.Transport.Frames
{

	public class Performative
	{
		Performative(string name, PerformativeType type)
		{
			Name = name;
			Type = type;
		}

		public string Name { get; private set; }

		public PerformativeType Type { get; private set; }

		public bool ContainsTypeOf (string content)
		{
			return content.HasFirstWord (Name);
		}

		public FrameBody GetFrameBody (byte[] frameBodyBytes)
		{
			var length = Name.Length;
			var body = new byte[frameBodyBytes.Length - length];
			Array.Copy (frameBodyBytes, length, body, 0, body.Length);
			return new FrameBody (Type, body);
		}

		public static IEnumerable<Performative> All {
			get {
				return new Performative[] {
					new Performative (Performatives.Attach, PerformativeType.Attach),
					new Performative(Performatives.Begin, PerformativeType.Begin),
					new Performative(Performatives.Close, PerformativeType.Close),
					new Performative(Performatives.Detach, PerformativeType.Detach),
					new Performative(Performatives.Disposition, PerformativeType.Disposition),
					new Performative(Performatives.End, PerformativeType.End),
					new Performative(Performatives.Flow, PerformativeType.Flow),
					new Performative(Performatives.Open, PerformativeType.Open),
					new Performative(Performatives.Transfer, PerformativeType.Transfer)
				};
			}
		}
	}
}
