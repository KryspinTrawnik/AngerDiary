using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Moq;
using AngerDiary.App.Concrete;

namespace AngryDiary.Tests
{
     public class AvaregeAngerLevelServiceTest
    {
        [Fact]
        public void GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate_IsNotNull()
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            var avaregeAngerLevelService = new AvaregeAngerLevelService();
            avaregeAngerLevelService.SetEventService(eventService);
            //Act
            avaregeAngerLevelService.GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate();
            //Assert
            avaregeAngerLevelService.AverageAngerSignalItems.Should().NotBeNull();
        }
        [Fact]
        public void GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate_CountAndDatesAreCorrect()
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            var avaregeAngerLevelService = new AvaregeAngerLevelService();
            avaregeAngerLevelService.SetEventService(eventService);
            var ExpectedTheNearestDate = new DateTime(2020, 11, 3, 11, 0, 0);
            var ExpectedMonthEarlierDate = new DateTime(2020, 10, 3, 11, 0, 0);
            //Act
            avaregeAngerLevelService.GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate();
            //Assert
            avaregeAngerLevelService.AverageAngerSignalItems.GeneralAngerLevelList.Count.Should().Be(4);
            avaregeAngerLevelService.AverageAngerSignalItems.AllDates.Count.Should().Be(4);
            avaregeAngerLevelService.AverageAngerSignalItems.TheNearestDate.Should().Be(ExpectedTheNearestDate);
            avaregeAngerLevelService.AverageAngerSignalItems.MonthEarlierDate.Should().Be(ExpectedMonthEarlierDate);

        }
        [Fact]
        public void GetMonthEarlierAngerLevelListAndAverages_IsNotNull()
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            var avaregeAngerLevelService = new AvaregeAngerLevelService();
            avaregeAngerLevelService.SetEventService(eventService);
            avaregeAngerLevelService.GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate();
            //Act
            avaregeAngerLevelService.GetMonthEarlierAngerLevelListAndAverages();
            //Assert
            avaregeAngerLevelService.AverageAngerSignalItems.MonthEarlierAngerLevelList.Should().NotBeNull();
           
        }
    }
}
