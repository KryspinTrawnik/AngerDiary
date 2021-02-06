using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;
  

namespace AngryDiary.Tests
{
    public class StageServiceTests
    {
        [Fact]
        public void GetNotUsedStage_IsNotNull()
        {
            //Arrange
            var stageService = new StageService();
            stageService.Items[1].HasBeenUsed = true;
            //Act
            var result = stageService.GetNotUsedStage();
            //Assert
            result.Should().NotBeEmpty();
        }
        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 4)]
        [InlineData(3, 3)]
        public void GetNotUsedStage_ReturnsCorrectNumberOfItems(int decreaseAmount, int expected)
        {
            //Arrange
            var stageService = new StageService();
            for(int x = 0; x < decreaseAmount; x++)
            {
                stageService.Items[x].HasBeenUsed = true;
            }
            //Act
            var result = stageService.GetNotUsedStage();
            //Assert
            result.Count.Should().Be(expected);
        }
        [Fact]
        public void GetMostValueStage_IsNotNull()
        {
            //Arrange
            var stageService = new StageService();

            //Act
            var result = stageService.GetMostValueStage(stageService.Items);
            //Assert
            result.Should().NotBeNull().And.BeOfType<Stage>();

        }
        [Fact]
        public void GetMostValueStage_ReturnRightStage()
        {
            //Arrange
            var stageService = new StageService();
            Stage expected = stageService.Items[2];
            //Act
            var result = stageService.GetMostValueStage(stageService.Items);
            //Assert
            result.Should().BeSameAs(expected);

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void FindStageById_NotReturnNull(int id)
        {
            //Arranget 
            var stageService = new StageService();
            //Act   
            var result = stageService.FindStageById(id);
            //Assert
            result.Should().NotBeNull();
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void FindStageById_ReturnRightStage(int id)
        {
            //Arranget 
            var stageService = new StageService();
            var actual = stageService.Items[id - 1];
            //Act   
            var result = stageService.FindStageById(id);
            //Assert
            result.Should().BeEquivalentTo(actual);
        }


    }
}
