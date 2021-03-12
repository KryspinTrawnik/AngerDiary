using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;

namespace AngryDiary.Tests
{  
    public class AngerSignalServiceTest
    {
        [Fact]
        public void ReturnNotUsedSignaltTest_WhenNoEmptyReturnUnused()
        {
            //Arrange
            var angerSignalService = new AngerSignalService();
            angerSignalService.Items[1].HasBeenUsed = true;

            //Act
            var result = angerSignalService.ReturnNotUsedSignal();

            //Assert
            result.Should().NotBeEmpty();
            result.Count.Should().Be(8);
        }
        [Fact]
        public void ReturnNotUsedSignal_ReturnEmpty()
        {
            //Arrange
            var angerSignalService = new AngerSignalService();
            angerSignalService.Items.ForEach(s => s.HasBeenUsed = true );

            //Act
            var result = angerSignalService.ReturnNotUsedSignal();

            //Assert
            result.Should().BeEmpty();
        }
    }

}
