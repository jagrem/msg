using System;
using FluentAssertions;
using Msg.Core.Transport.Frames;
using Xunit;

namespace Msg.Core.Specs.Transport.Frames
{
    public class DataOffsetSpecs
    {
        [Fact]
        public void Given_a_size_less_than_the_minimum_frame_header_size_When_creating_a_data_offset_Then_an_argument_exception_is_thrown()
        {
            // Act
            Action action = () => new DataOffset(1);

            // Assert
            action
                .Should().Throw<ArgumentException>()
                .WithMessage("Data offset size must be at least equivalent to the minimum allowable header size.\nParameter name: value");
        }

        [Fact]
        public void Given_a_size_greater_than_or_equal_to_the_minimum_frame_header_size_When_creating_a_data_offset_Then_a_data_offset_is_returned()
        {
            // Act
            var dataOffset = new DataOffset(3);

            // Assert
            dataOffset.Size.Should().Be(3);
        }

        [Fact]
        public void When_creating_a_data_offset_Then_a_data_offset_size_in_bytes_is_returned()
        {
            // Act
            var dataOffset = new DataOffset(3);

            // Assert
            dataOffset.SizeInBytes.Should().Be(12);
        }
    }
}
