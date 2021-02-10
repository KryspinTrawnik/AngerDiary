using AngerDiary.Domain.Entity;
using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;
using System.Collections.Generic;


namespace AngryDiary.Tests
{
    public class StageServiceHelperTests
    {
        [Fact]
        public void PickFromInitialList_IsNotNull()
        {
            //Arrange
            var result = new List<Stage>();
            //Act
            result = result.PickFromInitialList();
            //Assert
            result.Should().NotBeEmpty();
        }

        [Theory]
            [InlineData(1, "Recognizing triggers", false, 10)]
            [InlineData(2, "Recognizing signals of anger", false, 11)]
            [InlineData(3, "Using anger reducers", false, 12)]
            [InlineData(4, "Self-instruction to keep yourself calm", false, 9)]
            [InlineData(5, "Self-rewarding for good effort", false, 7)]
            [InlineData(6, "Looking at the good or bad consequences", false, 8)]
        public void PickFromInitialList_ReturnsCorrectData(int id, string name, bool hasBeenUsed, int value)
        {
            //Arrange
            var result = new List<Stage>();
            
            //Act
            result = result.PickFromInitialList();
            //Assert
            result[id - 1].Name.Should().Be(name);
            result[id - 1].HasBeenUsed.Should().Be(hasBeenUsed);
            result[id - 1].Value.Should().Be(value);
        }
    }
}
