using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;

namespace AngryDiary.Tests
{
    public class StrongSideServiceTests
    {

        [Fact]
        public void StrongSidesCount_IsNotNull()
        {
            //Arrange
            var strongSideService = new StrongSideService();
            var strongSideItems = new StrongSideItems();
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            //Act
            strongSideItems = strongSideService.StrongSidesCount(eventService);
            //Assert
            strongSideItems.Should().NotBeNull();
        }
        [Fact]
        public void StrongSidesCount_ReturnsCorrectStrongSideId()
        {
            //Arrange
            var strongSideService = new StrongSideService();
            var result = new StrongSideItems();
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            //Act
            result = strongSideService.StrongSidesCount(eventService);
            //Assert
            result.StrongSideId.Should().Be(1);
        }
        [Fact]
        public void StrongSidesCount_ReturnsCorrectSecondStrongSideId()
        {
            //Arrange
            var strongSideService = new StrongSideService();
            var result = new StrongSideItems();
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            //Act
            result = strongSideService.StrongSidesCount(eventService);
            //Assert
            result.SecondStrongSideId.Should().Be(2);
        }
        [Theory]
        [InlineData(3, "Using anger reducers", false, 12)]
        [InlineData(4, "Self-instruction to keep yourself calm", false, 9)]
        [InlineData(5, "Self-rewarding for good effort", false, 7)]
        [InlineData(6, "Looking at the good or bad consequences", false, 8)]
        public void StrongSidesCount_ReturnsCorrectStagesToImprove(int id, string name, bool hasBeenUsed, int value)
        {
            //Arrange
            var strongSideService = new StrongSideService();
            var result = new StrongSideItems();
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            var expected = new Stage(id, name, hasBeenUsed, value);
            //Act
            result = strongSideService.StrongSidesCount(eventService);
            //Assert
            result.StagesToImprove.Count.Should().Be(4);
            result.StagesToImprove.Find(stage => stage.Id == id).Should().BeEquivalentTo(expected);
        }
    }
}
