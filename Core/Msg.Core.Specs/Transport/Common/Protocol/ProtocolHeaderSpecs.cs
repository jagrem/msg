﻿using System;
using FluentAssertions;
using Msg.Core.Transport.Common.Protocol;
using Msg.Core.Transport.Common.Versioning;
using Xunit;

namespace Msg.Core.Specs.Transport.Common.Protocol
{
    public class ProtocolHeaderSpecs
    {
        static readonly Func<byte[], ProtocolHeader> convertByteArray = b => (ProtocolHeader)b;

        [Fact]
        public void Given_a_protocol_header_When_converting_to_a_byte_array_Then_it_starts_with_AMQP()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new ProtocolHeader(ProtocolIds.AMQP, new AmqpVersion(1, 2, 3));

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            byte[] result = subject;

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result[0..4].Should().ContainInOrder((byte)'A', (byte)'M', (byte)'Q', (byte)'P');
        }

        [Fact]
        public void Given_a_protocol_header_When_converting_to_a_byte_array_Then_it_contains_the_protocol_id()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new ProtocolHeader(ProtocolIds.AMQP, new AmqpVersion(1, 2, 3));

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            byte[] result = subject;

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().HaveElementAt(4, (byte)0);
        }

        [Fact]
        public void Given_a_protocol_header_When_converting_to_a_byte_array_Then_it_contains_the_version()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new ProtocolHeader(ProtocolIds.AMQP, new AmqpVersion(1, 2, 3));

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            byte[] result = subject;

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().ContainInOrder(new byte[] { 0, 1, 2, 3 });
        }

        [Fact]
        public void Given_a_byte_array_When_converting_to_a_protocol_header_Then_the_version_number_is_correct()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new byte[] { (byte)'A', (byte)'M', (byte)'Q', (byte)'P', (byte)0, (byte)1, (byte)2, (byte)3 };

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = (ProtocolHeader)subject;

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Version.Major.Should().Be(1);
            result.Version.Minor.Should().Be(2);
            result.Version.Revision.Should().Be(3);
        }

        [Fact]
        public void Given_a_byte_array_When_converting_to_a_protocol_header_Then_protocol_id_is_correct()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new byte[] { (byte)'A', (byte)'M', (byte)'Q', (byte)'P', (byte)0, (byte)1, (byte)2, (byte)3 };

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = (ProtocolHeader)subject;

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.ProtocolId.Should().Be(ProtocolIds.AMQP);
        }

        [Fact]
        public void Given_an_empty_byte_array_When_converting_to_a_protocol_header_Then_an_exception_is_thrown()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new byte[0];

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action result = () => convertByteArray(subject);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Given_a_byte_array_that_is_too_short_When_converting_to_a_protocol_header_Then_an_exception_is_thrown()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new byte[] { (byte)'A', (byte)'M', (byte)'Q', (byte)'P', (byte)0, (byte)1, (byte)2 };

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action result = () => convertByteArray(subject);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Given_a_byte_array_that_is_too_long_When_converting_to_a_protocol_header_Then_an_exception_is_thrown()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new byte[] { (byte)'A', (byte)'M', (byte)'Q', (byte)'P', (byte)0, (byte)1, (byte)2, (byte)3, (byte)4 };

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action result = () => convertByteArray(subject);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Given_a_byte_array_that_doesnt_start_with_AMQP_When_converting_to_a_protocol_header_Then_an_exception_is_thrown()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new byte[] { (byte)'Z', (byte)'S', (byte)'X', (byte)'F', (byte)0, (byte)1, (byte)2, (byte)3 };

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action result = () => convertByteArray(subject);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Given_a_byte_array_where_AMQP_is_not_all_uppercase_When_converting_to_a_protocol_header_Then_an_exception_is_thrown()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var subject = new byte[] { (byte)'a', (byte)'M', (byte)'q', (byte)'P', (byte)0, (byte)1, (byte)2, (byte)3 };

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action result = () => convertByteArray(subject);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().Throw<ArgumentException>();
        }
    }
}
