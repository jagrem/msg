using System;
using System.Text;
using FluentAssertions;
using Msg.Core.Transport.Frames;
using Msg.Core.Transport.Frames.Amqp.Serialization;
using Xunit;

namespace Msg.Core.Specs.Transport.Frames.Amqp.Serialization
{
    public class AmqpFrameSerializerSpecs
    {
        [Fact]
        public void Given_a_non_AMQP_frame_When_deserializing_a_frame_Then_an_argument_exception_is_thrown()
        {
            // Act
            Action action = () => AmqpFrameSerializer.Deserialize(new Frame(
                new FrameHeader(new FrameSize(13), new DataOffset(2), FrameHeaderType.SASL, 1),
                new FrameExtendedHeader(new byte[0]),
                new FrameBody(Encoding.ASCII.GetBytes("Begin"))));

            // Assert
            action
                .Should().Throw<ArgumentException>()
                .WithMessage("The frame must be of type AMQP.\nParameter name: frame");
        }
    }
}
