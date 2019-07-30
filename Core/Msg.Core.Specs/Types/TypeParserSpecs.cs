using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Msg.Core.Types;
using Xunit;

namespace Msg.Core.Specs.Transport.Frames
{
    public class TypeParserSpecs
    {
        public static IEnumerable<object[]> GetAllData()
        {
            return new List<object[]> {
                new object[] { new byte[] { 0x40 }, typeof(object), null },
                new object[] { new byte[] { 0x41 }, typeof(bool), true },
                new object[] { new byte[] { 0x42 }, typeof(bool), false },
                new object[] { new byte[] { 0x43 }, typeof(uint), 0 },
                new object[] { new byte[] { 0x44 }, typeof(ulong), 0 },

                // ubyte: 8-bit unsigned integer.
                new object[] { new byte[] { 0x50, 0x00 }, typeof(byte), 0 },
                new object[] { new byte[] { 0x50, 0x01 }, typeof(byte), 1 },
                new object[] { new byte[] { 0x50, 0xFF }, typeof(byte), 255 },

                // byte: 8-bit two's complement integer.
                new object[] { new byte[] { 0x51, 0x00 }, typeof(sbyte), 0 },
                new object[] { new byte[] { 0x51, 0x01 }, typeof(sbyte), 1 },
                new object[] { new byte[] { 0x51, 0xFF }, typeof(sbyte), -1 },
                new object[] { new byte[] { 0x51, 0x7F }, typeof(sbyte), 127 },
                new object[] { new byte[] { 0x51, 0x81 }, typeof(sbyte), -127 },

                // uint: unsigned integer value in the range 0 to 255 inclusive.
                new object[] { new byte[] { 0x52, 0x00 }, typeof(uint), 0 },
                new object[] { new byte[] { 0x52, 0x01 }, typeof(uint), 1 },
                new object[] { new byte[] { 0x52, 0xFF }, typeof(uint), 255 },

                // ulong: unsigned long value in the range 0 to 255 inclusive
                new object[] { new byte[] { 0x53, 0x00 }, typeof(ulong), 0 },
                new object[] { new byte[] { 0x53, 0x01 }, typeof(ulong), 1 },
                new object[] { new byte[] { 0x53, 0xFF }, typeof(ulong), 255 },

                // int: 8-bit two’s-complement integer.
                new object[] { new byte[] { 0x54, 0x00 }, typeof(int), 0 },
                new object[] { new byte[] { 0x54, 0x01 }, typeof(int), 1 },
                new object[] { new byte[] { 0x54, 0xFF }, typeof(int), -1 },
                new object[] { new byte[] { 0x54, 0x7F }, typeof(int), 127 },
                new object[] { new byte[] { 0x54, 0x81 }, typeof(int), -127 },

                // long: 8-bit two’s-complement integer.
                new object[] { new byte[] { 0x55, 0x00 }, typeof(long), 0 },
                new object[] { new byte[] { 0x55, 0x01 }, typeof(long), 1 },
                new object[] { new byte[] { 0x55, 0xFF }, typeof(long), -1 },
                new object[] { new byte[] { 0x55, 0x7F }, typeof(long), 127 },
                new object[] { new byte[] { 0x55, 0x81 }, typeof(long), -127 },

                // boolean: boolean with the octet 0x00 being false and octet 0x01 being true.
                new object[] { new byte[] { 0x56, 0x00 }, typeof(bool), false },
                new object[] { new byte[] { 0x56, 0x01 }, typeof(bool), true },

                // ushort: 16-bit unsigned integer in network byte order.
                new object[] { new byte[] { 0x60, 0x00, 0x00 }, typeof(ushort), 0 },
                new object[] { new byte[] { 0x60, 0x00, 0x01 }, typeof(ushort), 1 },
                new object[] { new byte[] { 0x60, 0x01, 0x00 }, typeof(ushort), 256 },
                new object[] { new byte[] { 0x60, 0xFF, 0xFF }, typeof(ushort), 65535 },

                // short: 16-bit two’s-complement integer in network byte order.
                new object[] { new byte[] { 0x61, 0x00, 0x00 }, typeof(short), 0 },
                new object[] { new byte[] { 0x61, 0x00, 0x01 }, typeof(short), 1 },
                new object[] { new byte[] { 0x61, 0xFF, 0xFF }, typeof(short), -1 },
                new object[] { new byte[] { 0x61, 0x7F, 0xFF }, typeof(short), 32767 },
                new object[] { new byte[] { 0x61, 0x80, 0x00 }, typeof(short), -32768 },

                // uint: 32-bit unsigned integer in network byte order.
                new object[] { new byte[] { 0x70, 0x00, 0x00, 0x00, 0x00 }, typeof(uint), 0 },
                new object[] { new byte[] { 0x70, 0x00, 0x00, 0x00, 0x01 }, typeof(uint), 1 },
                new object[] { new byte[] { 0x70, 0x00, 0x00, 0x01, 0x00 }, typeof(uint), 256 },
                new object[] { new byte[] { 0x70, 0x00, 0x01, 0x00, 0x00 }, typeof(uint), 65536 },
                new object[] { new byte[] { 0x70, 0x01, 0x00, 0x00, 0x00 }, typeof(uint), 16777216 },
                new object[] { new byte[] { 0x70, 0xFF, 0xFF, 0xFF, 0xFF }, typeof(uint), 4294967295 },

                // int: 32-bit two’s-complement integer in network byte order.
                new object[] { new byte[] { 0x71, 0x00, 0x00, 0x00, 0x00 }, typeof(int), 0 },
                new object[] { new byte[] { 0x71, 0x00, 0x00, 0x00, 0x01 }, typeof(int), 1 },
                new object[] { new byte[] { 0x71, 0xFF, 0xFF, 0xFF, 0xFF }, typeof(int), -1 },
                new object[] { new byte[] { 0x71, 0x00, 0x00, 0x01, 0x00 }, typeof(int), 256 },
                new object[] { new byte[] { 0x71, 0xFF, 0xFF, 0xFF, 0x00 }, typeof(int), -256 },
                new object[] { new byte[] { 0x71, 0x80, 0x00, 0x00, 0x00 }, typeof(int), -2147483648 },
                new object[] { new byte[] { 0x71, 0x7F, 0xFF, 0xFF, 0xFF }, typeof(int), 2147483647 },

                // ulong: 64-bit unsigned integer in network byte order.
                new object[] { new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, typeof(ulong), 0 },
                new object[] { new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 }, typeof(ulong), 1 },
                new object[] { new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00 }, typeof(ulong), 256 },
                new object[] { new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 }, typeof(ulong), 65536 },
                new object[] { new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 }, typeof(ulong), 16777216 },
                new object[] { new byte[] { 0x80, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 }, typeof(ulong), 4294967296 },
                new object[] { new byte[] { 0x80, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }, typeof(ulong), 1099511627776 },
                new object[] { new byte[] { 0x80, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, typeof(ulong), 281474976710656 },
                new object[] { new byte[] { 0x80, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, typeof(ulong), 72057594037927936 },
                new object[] { new byte[] { 0x80, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, typeof(ulong), 18446744073709551615 }
            };
        }

        [Theory]
        [MemberData(nameof(GetAllData))]
        public void Given_an_encoded_data_stream_When_parsing_the_data_stream_Then_the_correct_type_and_value_is_returned(byte[] value, Type expectedType, object expectedValue)
        {
            // Arrange
            var stream = new MemoryStream(value, false);

            // Act
            var results = TypeParser.Parse(stream);

            // Arrange
            results.Should().BeEquivalentTo((expectedType, expectedValue));
        }
    }
}
