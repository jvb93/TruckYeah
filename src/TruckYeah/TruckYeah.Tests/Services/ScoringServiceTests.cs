using TruckYeah.Services;
using Xunit;

namespace TruckYeah.Tests.Services
{
    public class ScoringServiceTests
    {
        private readonly ScoringService _classUnderTest;

        public ScoringServiceTests()
        {
            _classUnderTest = new ScoringService();
        }

        [Theory]
        [InlineData(15, 10, 5)]
        [InlineData(18, 60, 6)]
        [InlineData(50, 120, 10)]
        [InlineData(21, 26, 1)] // coprimes
        [InlineData(3, 7, 1)] // primes
        [InlineData(2, 11, 1)] // primes
        void GetGreatestCommonFactor_Should_Return_Known_Factors(int first, int second, int knownGcd)
        {
            Assert.Equal(knownGcd, _classUnderTest.GetGreatestCommonFactor(first, second));
        }

        [Theory]
        [InlineData("1234 Any Street", "Justin", 6)] // street name length is odd
        [InlineData("15 South Ranch", "Justin", 4.5)] // street name length is even
        [InlineData("15", "Justi", 3)] // street name length is even but both strings are prime length
        [InlineData("15f", "Justi", 3)] // street name length is odd but both strings are prime length
        void ScorePair_Should_Return_Known_Scores(string address, string driver, double knownScore)
        {
            Assert.Equal(knownScore, _classUnderTest.ScorePair(address, driver));
        }
    }
}