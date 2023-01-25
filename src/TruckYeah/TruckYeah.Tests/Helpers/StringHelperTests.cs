using System;
using TruckYeah.Helpers;
using Xunit;

namespace TruckYeah.Tests.Helpers
{
    public class StringHelperTests
    {
        [Theory]
        [InlineData("justin")]
        [InlineData("beth")]
        [InlineData("aaaaaaaaaaaaaaaaaaaa")]
        [InlineData("")]
        public void IsLengthEven_Should_Return_True_For_EvenLength_Strings(string theory)
        {
            Assert.True(theory.IsLengthEven());
        }

        [Theory]
        [InlineData("justina")]
        [InlineData("becky")]
        [InlineData("aaaaaaaaaaaaaaaaaaa")]
        public void IsLengthEven_Should_Return_False_For_OddLength_Strings(string theory)
        {
            Assert.False(theory.IsLengthEven());
        }

        [Theory]
        [InlineData("justina", 3)]
        [InlineData("becky", 1)]
        [InlineData("aeiou", 5)]
        public void GetVowelCount_Should_Return_Correct_Number_Of_Vowels(string theory, int knownCount)
        {
            Assert.Equal(knownCount, theory.GetVowelCount());
        }

        [Theory]
        [InlineData("justina", 4)]
        [InlineData("becky", 4)]
        [InlineData("aeiou", 0)]
        public void GetConsonantCount_Should_Return_Correct_Number_Of_Consonants(string theory, int knownCount)
        {
            Assert.Equal(knownCount, theory.GetConsonantCount());
        }
    }
}