using NUnit.Framework;
using System;
using Msg.Domain.Transport.Frames;
using FluentAssertions;
using System.Collections;

namespace Msg.UnitTests.Transport.Frames
{
	[TestFixture]
	public class FrameHeaderSpecs
	{
		[Test]
		[TestCaseSource(typeof(FrameHeaderTestCases), "ByteArraysWithLengthNotEqualToEight")]
		public void Given_an_array_of_bytes_with_length_not_equal_to_eight_When_creating_a_frame_header_from_a_byte_array_Then_throws_exception(byte[] bytes)
		{
			Action action = () => new FrameHeader (bytes);
			action.ShouldThrow<ArgumentException> ()
				.WithMessage ("A frame header has a fixed length of 8 bytes.*");
		}

		[Test]
		public void Given_the_size_field_is_not_greater_than_eight_When_creating_a_frame_header_from_a_byte_array_Then_throws_exception()
		{
			var bytes = new byte[] { 0, 0, 0, 0, 255, 0, 0, 0 };
			Action action = () => new FrameHeader (bytes);
			action.ShouldThrow<MalformedFrameException> ()
				.WithMessage ("The reported size of the frame header is less than 8 bytes.");
		}

		[Test]
		public void Given_a_size_field_of_100_When_creating_a_frame_header_from_a_byte_array_Then_the_size_equals_100()
		{
			var bytes = new byte[] { 0, 0, 0, 100, 255, 0, 0, 0 };
			var subject = new FrameHeader (bytes);
			subject.Size.Should ().Be (100);
		}

		[Test]
		public void Given_a_size_field_of_256_When_creating_a_frame_header_from_a_byte_array_Then_the_size_equals_256()
		{
			var bytes = new byte[] { 0, 0, 1, 0, 255, 0, 0, 0 };
			var subject = new FrameHeader (bytes);
			subject.Size.Should ().Be (256);
		}

		[Test]
		public void Given_a_size_field_of_65536_When_creating_a_frame_header_from_a_byte_array_Then_the_size_equals_65536()
		{
			var bytes = new byte[] { 0, 1, 0, 0, 255, 0, 0, 0 };
			var subject = new FrameHeader (bytes);
			subject.Size.Should ().Be (65536);
		}

		[Test]
		public void Given_a_size_field_of_16777216_When_creating_a_frame_header_from_a_byte_array_Then_the_size_equals_16777216()
		{
			var bytes = new byte[] { 1, 0, 0, 0, 255, 0, 0, 0 };
			var subject = new FrameHeader (bytes);
			subject.Size.Should ().Be (16777216);
		}

		[Test]
		public void Given_a_size_field_of_4294967295_When_creating_a_frame_header_from_a_byte_array_Then_the_size_equals_4294967295()
		{
			var bytes = new byte[] { 255, 255, 255, 255, 255, 0, 0, 0 };
			var subject = new FrameHeader (bytes);
			subject.Size.Should ().Be (4294967295);
		}

		[Test]
		public void Given_the_data_offset_field_is_not_greater_than_eight_When_creating_a_frame_header_from_a_byte_array_Then_throw_exception()
		{
			var bytes = new byte[] { 0, 0, 0, 255, 0, 0, 0, 0 };
			Action action = () => new FrameHeader (bytes);
			action.ShouldThrow<MalformedFrameException> ()
				.WithMessage ("Data offset cannot be less than 8 bytes.");
		}

		[Test]
		public void Given_a_data_offset_field_of_4_When_creating_a_frame_header_from_a_byte_array_Then_the_data_offset_equals_16()
		{
			var bytes = new byte[] { 0, 0, 0, 255, 4, 0, 0, 0 };
			var subject = new FrameHeader (bytes);
			subject.DataOffset.Should ().Be (16);
		}

		[Test]
		public void Given_a_type_field_of_zero_When_creating_a_frame_header_from_a_byte_array_Then_the_type_equals_AMQP()
		{
			var bytes = new byte[] { 0, 0, 0, 255, 255, 0, 0, 0 };
			var subject = new FrameHeader (bytes);
			subject.Type.Should ().Be (FrameHeaderType.AMQP);
		}

		[Test]
		public void Given_a_type_field_of_one_When_creating_a_frame_header_from_a_byte_array_Then_the_type_equals_SASL()
		{
			var bytes = new byte[] { 0, 0, 0, 255, 255, 1, 0, 0 };
			var subject = new FrameHeader (bytes);
			subject.Type.Should ().Be (FrameHeaderType.SASL);
		}

		[Test]
		public void Given_a_type_field_greater_than_one_When_creating_a_frame_header_from_a_byte_array_Then_throws_exception()
		{
			var bytes = new byte[] { 0, 0, 0, 255, 255, 3, 0, 0 };
			Action action = () => new FrameHeader (bytes);
			action.ShouldThrow<NotSupportedException> ()
				.WithMessage ("The frame header type is not supported.");
		}

		[Test]
		public void Given_a_channel_id_field_of_257_When_creating_a_frame_header_from_a_byte_array_Then_channel_id_equals_257()
		{
			var bytes = new byte[] { 0, 0, 0, 255, 4, 0, 1, 1 };
			var subject = new FrameHeader (bytes);
			subject.DataOffset.Should ().Be (16);
		}
	}

	class FrameHeaderTestCases
	{
		public IEnumerable ByteArraysWithLengthNotEqualToEight()
		{
			yield return new TestCaseData (new byte[] { 0, 1, 2, 3, 4, 5, 6 });
			yield return new TestCaseData (new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
		}
	}
}

