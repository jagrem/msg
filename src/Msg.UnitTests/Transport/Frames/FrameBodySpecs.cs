using NUnit.Framework;
using System;
using Msg.Domain.Transport.Frames;
using FluentAssertions;
using System.Text;

namespace Msg.UnitTests.Transport.Frames
{
	[TestFixture]
	public class FrameBodySpecs
	{
		[Test]
		public void Given_a_frame_body_byte_array_with_no_performative_When_creating_a_frame_body_Then_throw_exception()
		{
			var frameBodyBytes = new byte[] { 0, 0, 0, 0, 0 };
			Action action = () => new FrameBody (frameBodyBytes);
			action.ShouldThrow<MalformedFrameException> ()
				.WithMessage ("Cannot determine the type of frame.");
		}

		[Test]
		[TestCase("begin")]
		public void Given_a_frame_body_byte_array_with_a_performative_When_creating_a_frame_body_Then_performative_equals_byte_array_performative(string expectedPerformative)
		{
			var frameBodyBytes = ConvertToByteArray (expectedPerformative);
			var subject = new FrameBody (frameBodyBytes);
			subject.Performative.Should ().Be (expectedPerformative);
		}

		static byte[] ConvertToByteArray (string expectedPerformative)
		{
			var performativeBytes = Encoding.UTF8.GetBytes (expectedPerformative);
			var frameBodyBytes = new byte[performativeBytes.Length + 1];
			Array.Copy (performativeBytes, frameBodyBytes, performativeBytes.Length);
			frameBodyBytes [performativeBytes.Length] = 0;
			return frameBodyBytes;
		}
	}
}

