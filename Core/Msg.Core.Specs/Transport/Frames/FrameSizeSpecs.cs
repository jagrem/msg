using System;
using FluentAssertions;
using Msg.Core.Transport.Frames;
using Xunit;

namespace Msg.Core.Specs.Transport.Frames
{
    public class FrameSizeSpecs
    {
        [Fact]
        public void Given_a_size_less_than_the_minimum_frame_header_size_When_creating_a_frame_size_Then_an_argument_exception_is_thrown()
        {
            // Act
            Action action = () => new FrameSize(1);

            // Assert
            action
                .Should().Throw<ArgumentException>()
                .WithMessage("Frame size must be at least as large as the minimum allowable header size.\nParameter name: value");
        }

        [Fact]
        public void Given_a_size_greater_than_or_equal_to_the_minimum_frame_header_size_When_creating_a_frame_size_Then_a_frame_is_returned()
        {
            // Act
            var frameSize = new FrameSize(9);

            // Assert
            frameSize.Value.Should().Be(9);
        }
    }
}
