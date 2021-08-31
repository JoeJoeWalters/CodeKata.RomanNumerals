using Core;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Something_Does_Something_With_Thing_Expecting_SomethingElse()
        {
            // ARRANGE
            var thing = new Thing();

            // ACT

            // ASSERT
            thing.Should().NotBeNull();
        }

        [Theory]
        [InlineData("Scenario 1")]
        [InlineData("Scenario 2")]
        [InlineData("Scenario 3")]
        [InlineData("Scenario 4")]
        public void Something_Does_SomethingSpecific_With_Thing_Expecting_SomethingElse(string scenario)
        {
            // ARRANGE
            var thing = new Thing();

            // ACT

            // ASSERT
            thing.Should().NotBe(scenario);
        }
    }
}
