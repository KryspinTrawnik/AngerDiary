using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;

namespace AngryDiary.Tests
{
    public class ViewEventsLastMonthTests
    {
        [Fact]
        public void ViewLastMonth_IsNotEmpty()
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            var viewEventsLastMonth = new ViewEventsLastMonth();
            //Act
            var result = viewEventsLastMonth.ViewLastMonth(eventService);
            //Assert
            result.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void ViewLastMonth_ReturnsCorrectData(int id)
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            var viewEventsLastMonth = new ViewEventsLastMonth();
            var expected = eventService.Items.Find(x =>x.Id == id);
            if (id == 4)
                id = 3;
            //Act
            var result = viewEventsLastMonth.ViewLastMonth(eventService);
            //Assert
            result.Find(x => x.Id == id).Should().BeEquivalentTo(expected);
        }
    }
}
