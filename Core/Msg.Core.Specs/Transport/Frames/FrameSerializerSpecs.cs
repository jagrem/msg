using Xunit;
using System;
using Msg.Core.Transport.Frames;
using FluentAssertions;
using Msg.Core.Transport.Frames.Serialization;

namespace Msg.Core.Specs.Transport.Frames
{
    public class FrameSerializerSpecs
    {
        [Fact]
        public void Given_an_empty_byte_array_When_creating_a_frame_Then_an_exception_is_thrown()
        {
            // Arrange
            var frameBytes = new byte[0];

            // Act
            Action action = () => FrameSerializer.Deserialize(frameBytes);

            // Assert
            action
                .Should().Throw<MalformedFrameException>()
                .WithMessage("Frame must contain at least the mandatory frame header.");
        }

        [Fact]
        public void Given_a_frame_with_size_less_than_the_mandatory_frame_header_When_deserialized_Then_a_MalformedFrameException_is_thrown()
        {
            var frameBytes = new byte[] {
                0, 0, 0, 0,     // size
                2, 0, 0, 0      // header
            };

            // Act
            Action action = () => FrameSerializer.Deserialize(frameBytes);

            // Assert
            action
                .Should().Throw<MalformedFrameException>()
                .WithMessage("Frame size must be at least the size of the mandatory frame header.");
        }

        [Fact]
        public void Given_a_frame_where_the_size_is_less_than_the_number_of_bytes_in_the_frame_When_deserialized_Then_a_MalformedFrameException_is_thrown()
        {
            var frameBytes = new byte[] {
                0, 0, 0, 9,     // size
                2, 0, 0, 0      // header is too short
            };

            // Act
            Action action = () => FrameSerializer.Deserialize(frameBytes);

            // Assert
            action
                .Should().Throw<MalformedFrameException>()
                .WithMessage("Frame size must match the number of bytes in the frame.");
        }

        [Fact]
        public void Given_a_data_offset_less_than_the_mandatory_header_size_When_deserialized_Then_a_MalformedFrameException_is_thrown()
        {
            var frameBytes = new byte[] {
                0, 0, 0, 8,     // size
                0, 0, 0, 0      // header
            };

            // Act
            Action action = () => FrameSerializer.Deserialize(frameBytes);

            // Assert
            action
                .Should().Throw<MalformedFrameException>()
                .WithMessage("Data offset must be at least the size of the mandatory frame header.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Given_a_valid_header_type_When_deserialized_Then_the_frame_should_be_returned(byte headerType)
        {
            var frameBytes = new byte[] {
                0, 0,          0, 8,     // size
                2, headerType, 0, 0      // header
            };

            // Act
            var frame = FrameSerializer.Deserialize(frameBytes);

            // Assert
            frame.Should().NotBeNull();
        }

        [Fact]
        public void Given_an_invalid_header_type_When_deserialized_Then_a_MalformedFrameException_is_thrown()
        {
            var frameBytes = new byte[] {
                0, 0, 0, 8,     // size
                2, 4, 0, 0      // header
            };

            // Act
            Action action = () => FrameSerializer.Deserialize(frameBytes);

            // Assert
            action
                .Should().Throw<NotSupportedException>()
                .WithMessage("The frame header type is not supported.");
        }

        // TODO: Add tests for channelID

        [Fact]
        public void Given_an_extended_header_When_deserialized_Then_the_extended_header_is_returned()
        {
            var frameBytes = new byte[] {
                0, 0, 0, 12,     // size
                3, 0, 0, 0,      // header
                1, 2, 3, 4       // extended header
            };

            // Act
            var frame = FrameSerializer.Deserialize(frameBytes);

            // Assert
            frame.ExtendedHeader.Data.Should().Equal(new byte[] { 1, 2, 3, 4 });
        }

        [Fact]
        public void Given_a_body_When_deserialized_Then_the_body_is_returned()
        {
            var frameBytes = new byte[] {
                0, 0, 0, 12,     // size
                2, 0, 0, 0,      // header
                1, 2, 3, 4       // extended header
            };

            // Act
            var frame = FrameSerializer.Deserialize(frameBytes);

            // Assert
            frame.Body.Payload.Should().Equal(new byte[] { 1, 2, 3, 4 });
        }

        [Fact]
        public void Given_an_extended_header_and_a_body_When_deserialized_Then_the_extended_header_and_body_are_returned()
        {
            var frameBytes = new byte[] {
                0, 0, 0, 16,     // size
                3, 0, 0, 0,      // header
                1, 2, 3, 4,      // extended header
                5, 6, 7, 8       // body
            };

            // Act
            var frame = FrameSerializer.Deserialize(frameBytes);

            // Assert
            frame.ExtendedHeader.Data.Should().Equal(new byte[] { 1, 2, 3, 4 });
            frame.Body.Payload.Should().Equal(new byte[] { 5, 6, 7, 8 });
        }
    }
}
