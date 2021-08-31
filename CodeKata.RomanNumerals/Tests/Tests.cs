using Core;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly RomanNumeralConverter converter;

        public Tests()
        {
            converter = new RomanNumeralConverter();
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        public void Value_To_Numeral_Equals_ExpectedValue(int digit, string numeral)
        {
            // ARRANGE
            var thing = new RomanNumeralConverter();

            // ACT
            string result = converter.FromDigit(digit);

            // ASSERT
            result.Should().Be(numeral);
        }
    }
}
