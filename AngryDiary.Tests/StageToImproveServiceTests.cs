using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;


namespace AngryDiary.Tests
{
    public class StageToImproveServiceTests
    {
        [Fact]
        public void StageToImprove_IsNotNull()
        {
            //Act
            var stageService = new StageService();
            var stageToImproveService = new StageToImproveService();
            var result = new Stage();
            //Arrange
            result = stageToImproveService.StageToImprove(stageService.Items);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void StageToImprove_ReturnsCorrectData()
        {
            //Act
            var stageService = new StageService();
            var stageToImproveService = new StageToImproveService();
            var result = new Stage();
            //Arrange
            result = stageToImproveService.StageToImprove(stageService.Items);
            //Assert
            result.Should().Be(stageService.Items[2]);
        }
    }
}
