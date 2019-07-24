using System;
using FluentAssertions;
using Msg.Core.Transport.Frames;
using Xunit;

namespace Msg.Core.Specs.Transport.Frames
{
    public class FrameSpecs
    {
        [Fact]
        public void Given_a_size_that_differs_from_the_actual_number_of_bytes_When_creating_a_frame_Then_an_argument_exception_is_thrown()
        {
            // Act
            Action action = () => new Frame(new FrameHeader(new FrameSize(9), new DataOffset(2), FrameHeaderType.AMQP, 0), new FrameExtendedHeader(new byte[0]), new FrameBody(new byte[0]));

            // Assert
            action
                .Should().Throw<ArgumentException>()
                .WithMessage("Frame size must match the number of bytes in the frame.\nParameter name: header");
        }

        [Fact]
        public void Given_a_data_offset_that_differs_from_the_actual_number_of_bytes_When_creating_a_frame_Then_an_argument_exception_is_thrown()
        {
            // Act
            Action action = () => new Frame(new FrameHeader(new FrameSize(8), new DataOffset(3), FrameHeaderType.AMQP, 0), new FrameExtendedHeader(new byte[0]), new FrameBody(new byte[0]));

            // Assert
            action
                .Should().Throw<ArgumentException>()
                .WithMessage("Offset must match the number of bytes in the headers.\nParameter name: header");
        }

        [Fact]
        public void Given_a_size_equal_to_actual_number_of_bytes_When_creating_a_frame_Then_a_frame_is_returned()
        {
            // Act
            var frame = new Frame(new FrameHeader(new FrameSize(8), new DataOffset(2), FrameHeaderType.AMQP, 0), new FrameExtendedHeader(new byte[0]), new FrameBody(new byte[0]));

            // Assert
            frame.Should().NotBeNull();
        }
    }
}
