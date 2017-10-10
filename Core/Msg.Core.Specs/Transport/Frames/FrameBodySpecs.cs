using Xunit;
using System;
using Msg.Core.Transport.Frames;
using FluentAssertions;
using System.Text;
using Msg.Core.Transport.Frames.Factories;
using System.Threading.Tasks;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Specs.Transport.Frames
{
    public class FrameBodySpecs
    {
        [Fact]
        public void Given_a_frame_body_byte_array_with_no_performative_When_creating_a_frame_body_Then_throw_exception ()
        {
            var frameBodyBytes = new byte[] { 0, 0, 0, 0, 0 };
            Func<Task> action = async () => await FrameBodyFactory.GetFrameBodyFromBytes (frameBodyBytes);
            action.ShouldThrow<MalformedFrameException> ()
                .WithMessage ("Unrecognised frame type.");
        }

        [Theory]
        [InlineData ("Attach", PerformativeType.Attach)]
        [InlineData ("Begin", PerformativeType.Begin)]
        [InlineData ("Open", PerformativeType.Open)]
        [InlineData ("Flow", PerformativeType.Flow)]
        [InlineData ("Transfer", PerformativeType.Transfer)]
        [InlineData ("Disposition", PerformativeType.Disposition)]
        [InlineData ("Close", PerformativeType.Close)]
        [InlineData ("Detach", PerformativeType.Detach)]
        [InlineData ("End", PerformativeType.End)]
        public async Task Given_a_frame_body_byte_array_with_a_performative_When_creating_a_frame_body_Then_performative_equals_byte_array_performative (string performative, PerformativeType expectedType)
        {
            var frameBodyBytes = ConvertToByteArray (performative);
            var result = await FrameBodyFactory.GetFrameBodyFromBytes (frameBodyBytes);
            result.Performative.Should ().Be (expectedType);
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

