using System;

namespace Msg.Core.Transport.Frames.Behaviour
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public sealed class HandledAtConnectionlevelAttribute : HandlingBehaviourAttribute
	{
	}
}

