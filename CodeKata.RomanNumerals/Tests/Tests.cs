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
        public void Numeral_To_Digit_Equals_ExpectedValue(int digit, string numeral)
        {
            // ARRANGE
            var thing = new RomanNumeralConverter();

            // ACT
            int fromNumeral = converter.FromNumerals(numeral);

            // ASSERT
            fromNumeral.Should().Be(digit);
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
        public void Digit_To_Numeral_Equals_ExpectedValue(int digit, string numeral)
        {
            // ARRANGE
            var thing = new RomanNumeralConverter();

            // ACT
            string fromDigit = converter.FromDigit(digit);

            // ASSERT
            fromDigit.Should().Be(numeral);
        }
    }
}
