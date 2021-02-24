using System;
using FluentAssertions;
using Xunit;
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
            eventService.AddRangeOfEvents(TestEvents);
            var averageAngerLevelService = new AvaregeAngerLevelService();
            averageAngerLevelService.SetEventService(eventService);
            //Act
            averageAngerLevelService.GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate();
            //Assert
            averageAngerLevelService.AverageAngerSignalItems.Should().NotBeNull();
        }
        [Fact]
        public void GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate_CountAndDatesAreCorrect()
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddRangeOfEvents(TestEvents);
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
            eventService.AddRangeOfEvents(TestEvents);
            var avaregeAngerLevelService = new AvaregeAngerLevelService();
            avaregeAngerLevelService.SetEventService(eventService);
            avaregeAngerLevelService.GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate();
            //Act
            avaregeAngerLevelService.GetMonthEarlierAngerLevelListAndAverages();
            //Assert
            avaregeAngerLevelService.AverageAngerSignalItems.MonthEarlierAngerLevelList.Should().NotBeNull();
        }
        [Fact]
        public void GetMonthEarlierAngerLevelListAndAverages_ReturnsCorrectData()
        {
            //Arrange
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddRangeOfEvents(TestEvents);
            var avaregeAngerLevelService = new AvaregeAngerLevelService();
            avaregeAngerLevelService.SetEventService(eventService);
            avaregeAngerLevelService.GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate();
            //Act
            avaregeAngerLevelService.GetMonthEarlierAngerLevelListAndAverages();
            //Assert
            avaregeAngerLevelService.AverageAngerSignalItems.GeneralAverage.Should().BeApproximately(6,25);
            avaregeAngerLevelService.AverageAngerSignalItems.MonthEarlierAverage.Should().BeApproximately(5, 666);
            avaregeAngerLevelService.AverageAngerSignalItems.DifferenceBetweenAverges.Should().BeApproximately(0, 5833);
        }
        [Fact]
        public void GetPerecntageDifferenceAndText_ReturnsCorrectData()
        {
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddRangeOfEvents(TestEvents);
            var averageAngerLevelService = new AvaregeAngerLevelService();
            averageAngerLevelService.SetEventService(eventService);
            averageAngerLevelService.GetAllDates_AngerLevelListsAndTheNearest_MonthEarlierDate();
            averageAngerLevelService.GetMonthEarlierAngerLevelListAndAverages();
            //Act
            averageAngerLevelService.GetPerecntageDifferenceAndText();
            //Assert
            averageAngerLevelService.AverageAngerSignalItems.PrecentageDifferenceBetweenAverges.Should().BeApproximately(0, 1029);
            averageAngerLevelService.AverageAngerSignalItems.IncreasedOrDeacresedText.Should().Be("It has increased from the last month by");
        }
    }
}
