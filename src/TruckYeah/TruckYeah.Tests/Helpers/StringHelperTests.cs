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
    }
}