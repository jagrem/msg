using NUnit.Framework;
using Msg.Core.Versioning;
using FluentAssertions;

namespace Msg.Core.Specs.Versioning
{
    [TestFixture]
    public class VersionNegotiatorSpecs
    {
        [Test]
        [Property ("Issue", "2")]
        public void Given_a_client_prefers_a_lower_version_than_the_version_the_server_prefers_When_negotiating_which_version_to_use_Then_the_server_returns_the_clients_preferred_version ()
        {
            var clientSupportedVersions = new ClientSupportedVersions (Version.Exactly (1, 0, 0));
            var serverSupportedVersions = new ServerSupportedVersions (Version.From (1, 0, 0).To (1, 1, 0));

            var result = VersionNegotiator.Select (clientSupportedVersions, serverSupportedVersions);

            result.Should ().Be (new AcceptedVersion (1, 0, 0));
        }

        [Test]
        [Property ("Issue", "3")]
        public void Given_a_client_prefers_a_version_which_the_server_does_not_support_When_negotiating_which_version_to_use_Then_the_server_returns_its_preferred_version_And_closes_the_connection ()
        {
            var clientSupportedVersions = new ClientSupportedVersions (Version.Exactly (1, 0, 0));
            var serverSupportedVersions = new ServerSupportedVersions (Version.Exactly (1, 1, 0));

            var result = VersionNegotiator.Select (clientSupportedVersions, serverSupportedVersions);

            result.Should ().Be (new Version (1, 1, 0));
        }

        [Test]
        [Property ("Issue", "4")]
        public void Given_a_client_prefers_the_same_version_as_the_server_When_negotiating_which_version_to_use_Then_the_server_returns_the_clients_preferred_version ()
        {
            var clientSupportedVersions = new ClientSupportedVersions (Version.Exactly (1, 0, 0));
            var serverSupportedVersions = new ServerSupportedVersions (Version.Exactly (1, 0, 0));

            var result = VersionNegotiator.Select (clientSupportedVersions, serverSupportedVersions);

            result.Should ().Be (new AcceptedVersion (1, 0, 0));
        }
    }
}

