using Xunit;
using Msg.Core.Transport.Connections.Tcp;
using Msg.Core.Transport.Common.Versioning;
using System;
using FluentAssertions;

namespace Msg.Core.Specs.Transport.Connections.Tcp
{
    public class PortNumberSpecs
    {
        static PortNumber CastIntToPortNumber (int value)
        {
            return (PortNumber)value;
        }

        [Theory]
        [InlineData(65999)]
        public void Given_a_value_greater_than_the_maximum_port_number_allowed_When_casting_to_a_port_number_Then_it_should_throw (int value)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action result = () => CastIntToPortNumber (value);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.ShouldThrow<ArgumentOutOfRangeException> ();
        }

        [Theory]
        [InlineData (0)]
        [InlineData (-1)]
        public void Given_a_value_less_than_or_equal_to_zero_When_casting_to_a_port_number_Then_it_should_throw (int value)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action result = () => CastIntToPortNumber (value);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.ShouldThrow<ArgumentOutOfRangeException> ();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1024)]
        public void Given_a_value_When_casting_to_a_port_number_Then_the_port_number_equals_the_value (int value)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = CastIntToPortNumber (value);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should ().BeOfType<PortNumber> ();
            ((int)result).Should ().Be (value);
        }
    }
}

