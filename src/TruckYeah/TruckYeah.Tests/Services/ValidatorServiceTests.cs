using System.Collections.Generic;
using TruckYeah.Services;
using Xunit;

namespace TruckYeah.Tests.Services
{
    public class ValidatorServiceTests
    {
        private readonly ValidatorService _classUnderTest;

        public ValidatorServiceTests()
        {
            _classUnderTest = new ValidatorService();
        }

        [Fact]
        public void Validator_Should_Allow_Lists_Of_Equal_Length()
        {
            // Arrange
            var list1 = new List<string>() { "test" };
            var list2 = new List<string>() { "test" };

            // Act
            var validated = _classUnderTest.AreThereEnoughDriversForEachDelivery(list1, list2);

            // Assert
            Assert.True(validated);
        }

        [Fact]
        public void Validator_Should_Disallow_Lists_Of_Unequal_Length()
        {
            // Arrange
            var list1 = new List<string>() { };
            var list2 = new List<string>() { "test" };

            // Act
            var validated = _classUnderTest.AreThereEnoughDriversForEachDelivery(list1, list2);

            // Assert
            Assert.False(validated);
        }

        [Fact]
        public void Validator_Should_Disallow_Lists_Where_One_Is_Null()
        {
            // Arrange
            var list1 = new List<string>() { };

            // Act
            var validated = _classUnderTest.AreThereEnoughDriversForEachDelivery(list1, null);

            // Assert
            Assert.False(validated);
        }
    }
}