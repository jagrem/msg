using NUnit.Framework;
using Msg.Domain;
using FluentAssertions;

namespace Msg.UnitTests
{
	[TestFixture]
	public class VersionSpecs
	{
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
	}
}

