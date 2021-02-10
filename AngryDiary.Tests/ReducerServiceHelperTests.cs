using AngerDiary.Domain.Entity;
using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;
using System.Collections.Generic;


namespace AngryDiary.Tests
{
    public class ReducerServiceHelperTests
    {
        [Fact]
        public void PickFromInitialList_isNotNull()
        {
            //Arrange
            var result = new List<Reducer>();
            //Act
            result = result.PickFromInitialList();
            //Assert
            result.Should().NotBeNull();
        }
        [Theory]
        [InlineData(1, "Counting backward", false)]
        [InlineData(2, "Deep breathing", false)]
        [InlineData(3, "Thinking ahead (if - consequences)", false)]
        [InlineData(4, "Positive visualisation", false)]
        public void PickFromInitialList_ReturnsCorrectData(int id, string name, bool hasBeenUsed)
        {
            //Arrange
            var result = new List<Reducer>();
            
            //Act
            result = result.PickFromInitialList();
            //Assert
            result[id-1].Name.Should().Be(name);
            result[id-1].HasBeenUsed.Should().Be(hasBeenUsed);
        }
    }
}
