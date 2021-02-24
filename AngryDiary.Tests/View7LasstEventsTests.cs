using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;

namespace AngryDiary.Tests
{
    public class View7LasstEventsTests
    {
        [Fact]
        public void Last7Events_IsNotNull()
        {
            //Act
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddRangeOfEvents(TestEvents);
            var view7LastEvents = new View7LastEvents();
            //Arrange
            var result =  view7LastEvents.Last7Events(eventService);
            //Assert
            result.Should().NotBeEmpty();
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Last7Events_ReturnsRightData(int id)
        {
            //Act
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddRangeOfEvents(TestEvents);
            var view7LastEvents = new View7LastEvents();
            var expected = eventService.Items.Find(x => x.Id == id);
            //Arrange
            var result = view7LastEvents.Last7Events(eventService);
            //Asset
            result.Find(x => x.Id == id).Should().Be(expected);
            
        }
    }
}
