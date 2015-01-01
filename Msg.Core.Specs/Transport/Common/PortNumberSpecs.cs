using NUnit.Framework;
using Msg.Core.Transport.Common;
using System;
using FluentAssertions;

namespace Msg.Core.Specs.Transport.Common
{
    [TestFixture]
    public class PortNumberSpecs
    {
        static PortNumber CastTo (int value)
        {
            return (PortNumber)value;
        }

        [Test]
        public void Given_a_value_greater_than_the_maximum_port_number_allowed_When_casting_to_a_port_number_Then_it_should_throw (int value)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action result = () => CastTo (value);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.ShouldThrow<ArgumentOutOfRangeException> ();
        }

        [Test]
        [TestCase (0)]
        [TestCase (-1)]
        public void Given_a_value_less_than_or_equal_to_zero_When_casting_to_a_port_number_Then_it_should_throw (int value)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action result = () => CastTo (value);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.ShouldThrow<ArgumentOutOfRangeException> ();
        }

        [Test]
        public void Given_a_value_When_casting_to_a_port_number_Then_the_port_number_equals_the_value ()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = CastTo (1028);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should ().BeOfType<PortNumber> ();
            ((int)result).Should ().Be (1028);
        }
    }
}

