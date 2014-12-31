﻿using NUnit.Framework;
using Msg.Core.Transport.Sessions;
using FluentAssertions;
using Msg.Core.Transport.Connections;
using System.Threading.Tasks;
using Msg.Core.Specs.Transport.Connections;

namespace Msg.Core.Specs.Transport.Sessions
{
    [TestFixture]
    public class SessionFactorySpecs
    {
        [Test]
        public async Task Given_a_connection_When_asked_for_a_session_Then_returns_a_different_session_each_time()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var connection = await (new ConnectionFactory ()).CreateOpenConnectionAsync ();
            var factory = new SessionFactory (connection);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result1 = factory.CreateSession ();
            var result2 = factory.CreateSession ();

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result1.Should ().NotBe (result2);
        }
    }
}

