using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;

namespace AngryDiary.Tests
{
    public class ReducerServiceTests
    {
        [Fact]
        public void GetNotUsedReducers_IsNotNull()
        {
            //Arrange
            var reducerService = new ReducerService();
            reducerService.Items[1].HasBeenUsed = true;
            reducerService.Items[3].HasBeenUsed = true;
            //Act
            var result = reducerService.GetNotUsedReducers();
            //Assert
            result.Should().NotBeEmpty();
        }
        [Fact]
        public void GetNotUsedReducers_LeftItemsAreTheSame()
        {
            //Arrange
            var reducerService = new ReducerService();
            reducerService.Items[1].HasBeenUsed = true;
            reducerService.Items[3].HasBeenUsed = true;
            var actual = reducerService.Items.FindAll(x => x.HasBeenUsed == false);
            //Act
            var result = reducerService.GetNotUsedReducers();
            //Assert
            result.Should().BeEquivalentTo(actual);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetReducerById_ReturnRightItem(int id)
        {
            //Arrange
            var reducerService = new ReducerService();
            var expected = reducerService.Items.Find(x => x.Id == id);
            //Act
            var result = reducerService.GetReducerById(id);
            //Assert
            result.Should().BeSameAs(expected);
            

        }

    }
}
