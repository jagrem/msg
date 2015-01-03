﻿using NUnit.Framework;
using Msg.Core.Versioning;
using FluentAssertions;

namespace Msg.Core.Specs.Versioning
{
    [TestFixture]
    public class VersionSelectorSpecs
    {
        [Test]
        [Property ("Issue", "2")]
        public void Given_a_client_prefers_a_lower_version_than_the_version_the_server_prefers_When_selecting_which_version_to_use_Then_the_server_returns_the_clients_preferred_version ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var clientVersion = new ClientVersion (1, 0, 0);
            var serverSupportedVersions = new ServerSupportedVersions (Version.From (1, 0, 0).To (1, 1, 0));

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = VersionSelector.Select (clientVersion, serverSupportedVersions);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should ().Be (new AcceptedVersion (clientVersion));
        }

        [Test]
        [Property ("Issue", "3")]
        [TestCase(1,0,0)]
        [TestCase(1,2,0)]
        public void Given_a_client_prefers_a_version_which_the_server_does_not_support_When_selecting_which_version_to_use_Then_the_server_returns_its_preferred_version_And_closes_the_connection (byte major, byte minor, byte revision)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var clientVersion = new ClientVersion (major, minor, revision);
            var serverSupportedVersions = new ServerSupportedVersions (Version.Exactly (1, 1, 0));

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = VersionSelector.Select (clientVersion, serverSupportedVersions);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should ().Be (new ServerVersion (new Version (1, 1, 0)));
        }

        [Test]
        [Property ("Issue", "4")]
        public void Given_a_client_prefers_the_same_version_as_the_server_When_selecting_which_version_to_use_Then_the_server_returns_the_clients_preferred_version ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var clientVersion = new ClientVersion (1, 0, 0);
            var serverSupportedVersions = new ServerSupportedVersions (Version.Exactly (1, 0, 0));

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = VersionSelector.Select (clientVersion, serverSupportedVersions);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should ().Be (new AcceptedVersion (clientVersion));
        }

        [Test]
        public void Given_a_malformed_client_version_When_selecting_which_version_to_use_Then_the_server_returns_its_preferred_version() 
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var clientVersion = new MalformedClientVersion ();
            var serverSupportedVersions = new ServerSupportedVersions (Version.Exactly (1, 1, 0));

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = VersionSelector.Select (clientVersion, serverSupportedVersions);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should ().Be (new ServerVersion (new Version (1, 1, 0)));
        }
    }
}
