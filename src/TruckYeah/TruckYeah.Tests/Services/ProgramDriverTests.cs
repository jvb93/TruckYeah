using System.Collections.Generic;
using System.Linq;
using Moq;
using TruckYeah.Services;
using Xunit;

namespace TruckYeah.Tests.Services
{
    public class ProgramDriverTests
    {
        private readonly ProgramDriver _classUnderTest;
        private readonly Mock<IFileReaderService> _fileReaderMock;
        private readonly Mock<IValidatorService> _validatorMock;
        private readonly Mock<IScoringService> _scoringMock;
        
        public ProgramDriverTests()
        {
            _fileReaderMock = new Mock<IFileReaderService>(MockBehavior.Strict);
            _validatorMock = new Mock<IValidatorService>(MockBehavior.Strict);
            _scoringMock = new Mock<IScoringService>(MockBehavior.Strict);
            
            _classUnderTest = new ProgramDriver(_fileReaderMock.Object, _validatorMock.Object, _scoringMock.Object);
        }

        [Fact]
        void ScoreAndSort_Should_Return_Empty_Dictionary_If_No_Addresses_Provided()
        {
            // Arrange
            var addresses = new List<string>();
            var drivers = new List<string>() { "JVB" };
            
            // Act
            var scores = _classUnderTest.ScoreAndSortDriverAddressCombos(addresses, drivers);
            
            // Assert
            Assert.Empty(scores);
        }
        [Fact]
        void ScoreAndSort_Should_Return_Empty_Dictionary_If_No_Drivers_Provided()
        {
            // Arrange
            var addresses = new List<string>() { "132 any street"};
            var drivers = new List<string>();
            
            // Act
            var scores = _classUnderTest.ScoreAndSortDriverAddressCombos(addresses, drivers);
            
            // Assert
            Assert.Empty(scores);
        }
        
        [Fact]
        void ScoreAndSort_Should_Return_Scored_Dictionary()
        {
            // Arrange
            var addresses = new List<string>() { "132 any street"};
            var drivers = new List<string>() { "JVB"};
            var expectedScore = 10.0;
            _scoringMock.Setup(x => x.ScorePair(addresses.First(), drivers.First())).Returns(expectedScore);
            
            // Act
            var scores = _classUnderTest.ScoreAndSortDriverAddressCombos(addresses, drivers);
            
            // Assert
            Assert.Single(scores, sc => sc.Value.Score == expectedScore);
        }
        
    }
}