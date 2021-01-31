using AngerDiary.App.Concrete;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AngryDiary.Tests
{
    public class EventServiceTests
    {
        [Fact]
        public void AddIdTest_CheckReturnedId()
        {
            //Arrange
            var eventService = new EventService();
            int expected = 1;
            //Act
            var actual = eventService.AddId();
            //Assert
            actual.Should().Be(expected);
        }
        [Fact]
        public void AddRange_IsNotNull()
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var testList = eventsForTests.TestEvents();
            //Act
            eventService.AddTestEvents(testList);
            //Assert
            eventService.Items.Should().NotBeEmpty();
        }
        [Fact]
        public void AddRange_ListCountIsRight()
        {
            //Arrange 
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var testList = eventsForTests.TestEvents();
            //Act
            eventService.AddTestEvents(testList);
            //Assert
            eventService.Items.Count.Should().Be(testList.Count);
        }
        [Fact]
        public void AddRange_IsListContentCorrect()
        {

            //Arrange 
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var testList = eventsForTests.TestEvents();
            //Act
            eventService.AddTestEvents(testList);
            //Assert
            for(int x = 1; x < eventService.Items.Count; x++)
            {
                eventService.Items[x].Should().Be(testList[x]);
            }
            
        }
    }
}
