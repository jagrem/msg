using NUnit.Framework;
using Msg.Domain;
using FluentAssertions;

namespace Msg.UnitTests
{
	[TestFixture]
	public class VersionRangeSpecs
	{
		[Test]
		[TestCase (1, 0, 1)]
		[TestCase (1, 0, 2)]
		[TestCase (1, 0, 3)]
		public void Given_a_version_range_with_upper_and_lower_bounds_When_version_range_contains_version_Then_returns_true (byte major, byte minor, byte revision)
		{
			var subject = Version.From (1, 0, 1).To (1, 0, 3);
			var result = subject.Contains (new Version (major, minor, revision));
			result.Should ().BeTrue ();
		}

		[Test]
		[TestCase (1, 0, 0)]
		[TestCase (1, 0, 4)]
		public void Given_a_version_range_with_upper_and_lower_bounds_When_version_range_does_not_contain_version_Then_returns_false(byte major, byte minor, byte revision)
		{
			var subject = Version.From (1, 0, 1).To (1, 0, 3);
			var result = subject.Contains (new Version (major, minor, revision));
			result.Should ().BeFalse ();
		}

		[Test]
		[TestCase (1, 0, 1)]
		[TestCase (0, 9, 2)]
		[TestCase (0, 0, 3)]
		public void Given_version_range_with_only_upper_bound_When_version_range_contains_version_Then_returns_true (byte major, byte minor, byte revision)
		{
			var subject = Version.UpTo (1, 0, 1);
			var result = subject.Contains (new Version (major, minor, revision));
			result.Should ().BeTrue ();
		}

		[Test]
		[TestCase (1, 0, 2)]
		public void Given_a_version_range_with_only_upper_bound_When_version_range_does_not_contain_version_Then_returns_false (byte major, byte minor, byte revision)
		{
			var subject = Version.UpTo (1, 0, 1);
			var result = subject.Contains (new Version (major, minor, revision));
			result.Should ().BeFalse ();
		}
				
		[Test]
		public void Given_a_version_range_with_exactly_one_version_When_version_range_contains_version_Then_returns_true()
		{
			var subject = Version.Exactly (1, 0, 1);
			var result = subject.Contains (new Version (1, 0, 1));
			result.Should ().BeTrue ();
		}

		[Test]
		[TestCase(1, 0, 2)]
		[TestCase(1, 0, 0)]
		public void Given_a_version_range_with_exactly_one_version_When_version_range_does_not_contain_version_Then_returns_false(byte major, byte minor, byte revision)
		{
			var subject = Version.Exactly (1, 0, 1);
			var result = subject.Contains (new Version (major, minor, revision));
			result.Should ().BeFalse ();
		}
	}
}

