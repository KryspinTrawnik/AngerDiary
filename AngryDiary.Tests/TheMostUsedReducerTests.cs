using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;

namespace AngryDiary.Tests
{
    public class TheMostUsedReducerTests
    {
        [Fact]
        public void FindMostUsedReducer_IsNotNull()
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            var theMostUsedReducer = new TheMostUsedReducer();
            eventService.AddTestEvents(TestEvents);
            //Act
            var result = theMostUsedReducer.FindMostUsedReducer(eventService);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void FindMostUsedReducer_IsCorrectReducer()
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            var theMostUsedReducer = new TheMostUsedReducer();
            eventService.AddTestEvents(TestEvents);
            var expected = new Reducer(1, "Counting backward", false);
            //Act
            var result = theMostUsedReducer.FindMostUsedReducer(eventService);
            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
