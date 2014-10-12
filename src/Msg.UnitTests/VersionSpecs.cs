using NUnit.Framework;
using Msg.Domain;
using FluentAssertions;
using System;
using Version = Msg.Domain.Version;

namespace Msg.UnitTests
{
	[TestFixture]
	public class VersionSpecs
	{
		static readonly Func<byte[],Version> convertByteArray = b => b;

		[Test]
		public void Given_any_version_When_converting_to_a_byte_array_Then_AMQP_followed_by_zero_are_the_first_five_bytes()
		{
			var subject = new Version (1, 2, 3);
			byte[] result = subject;
			result.Should ().ContainInOrder ((byte)'A', (byte)'M', (byte)'Q', (byte)'P', (byte)0);
		}

		[Test]
		public void Given_a_version_When_converting_to_a_byte_array_Then_the_sixth_byte_equals_the_major_version_number()
		{
			var subject = new Version (1, 2, 3);
			byte[] result = subject;
			result.Should ().HaveElementAt (5, (byte)1);
		}

		[Test]
		public void Given_a_version_When_converting_to_a_byte_array_Then_the_seventh_byte_equals_the_minor_version_number()
		{
			var subject = new Version (1, 2, 3);
			byte[] result = subject;
			result.Should ().HaveElementAt (6, (byte)2);
		}

		[Test]
		public void Given_a_version_When_converting_to_a_byte_array_Then_the_eight_byte_equals_the_revision_number()
		{
			var subject = new Version (1, 2, 3);
			byte[] result = subject;
			result.Should ().HaveElementAt (7, (byte)3);
		}

		[Test]
		public void Given_a_byte_array_When_converting_to_a_version_Then_the_version_number_is_correct()
		{
			var subject = new byte[] { (byte)'A', (byte)'M', (byte)'Q', (byte)'P', (byte)0, (byte)1, (byte)2, (byte)3 };
			Version result = subject;
			result.Major.Should ().Be (1);
			result.Minor.Should ().Be (2);
			result.Revision.Should ().Be (3);
		}

		[Test]
		public void Given_an_empty_byte_array_When_converting_to_a_version_Then_an_exception_is_thrown()
		{
			var subject = new byte[0];
			Action result = () => convertByteArray (subject);
			result.ShouldThrow<ArgumentException> ();
		}

		[Test]
		public void Given_a_byte_array_that_is_too_short_When_converting_to_a_version_Then_an_exception_is_thrown()
		{
			var subject = new byte[] { (byte)'Z', (byte)'S', (byte)'X', (byte)'F', (byte)0, (byte)1, (byte)2 };
			Action result = () => convertByteArray (subject);
			result.ShouldThrow<ArgumentException> ();
		}

		[Test]
		public void Given_a_byte_array_that_is_too_long_When_converting_to_a_version_Then_an_exception_is_thrown()
		{
			var subject = new byte[] { (byte)'Z', (byte)'S', (byte)'X', (byte)'F', (byte)0, (byte)1, (byte)2, (byte)3, (byte)4 };
			Action result = () => convertByteArray (subject);
			result.ShouldThrow<ArgumentException> ();
		}

		[Test]
		public void Given_a_byte_array_with_an_fifth_byte_greater_than_zero_When_converting_to_a_version_Then_an_exception_is_thrown()
		{
			var subject = new byte[] { (byte)'Z', (byte)'S', (byte)'X', (byte)'F', (byte)7, (byte)1, (byte)2, (byte)3 };
			Action result = () => convertByteArray (subject);
			result.ShouldThrow<ArgumentException> ();
		}

		[Test]
		public void Given_a_byte_array_that_doesnt_start_with_AMQP_When_converting_to_a_version_Then_an_exception_is_thrown()
		{
			var subject = new byte[] { (byte)'Z', (byte)'S', (byte)'X', (byte)'F', (byte)7, (byte)1, (byte)2, (byte)3 };
			Action result = () => convertByteArray (subject);
			result.ShouldThrow<ArgumentException> ();
		}
	}
}

