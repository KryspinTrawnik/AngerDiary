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
    public class RaportServiceTests
    {
        [Fact]
        public void CreateRaport_ReturnsCorrectId()
        {
            //Arrange
            var raportService = new RaportService();
            int expected = raportService.Items.Count + 1;
            var eventsService = new EventService();
            //Act
            var result = raportService.CreateRaport(eventsService);
            //Assert
            result.Id.Should().Be(expected);
        }
        [Fact]
        public void CreateRaport_ReturnsCorrectDate()
        {
            //Arrange
            var raportService = new RaportService();
            DateTime expected = DateTime.Today;
            var eventsService = new EventService();
            //Act
            var result = raportService.CreateRaport(eventsService);
            //Assert
            result.Date.Should().Be(expected);
        }
        [Fact]
        public void CreateRaport_ReturnsCorrectAvarege()
        {
            //Arrange
            var raportService = new RaportService();
            var eventsService = new EventService();
            var eventsForTest = new EventsForTest();
            var listOfEvents = eventsForTest.TestEvents();
            eventsService.AddRangeOfEvents(listOfEvents);
            //Act
            var result = raportService.CreateRaport(eventsService);
            //Assert
            result.AngerLevelAvarage.Should().BeApproximately(6, 25);
        }
        [Fact]
        public void CreateRaport_ReturnsCorrectStrongSide()
        {
            //Arrange
            var raportService = new RaportService();
            var eventsService = new EventService();
            var eventsForTest = new EventsForTest();
            var stageService = new StageService();
            var listOfEvents = eventsForTest.TestEvents();
            eventsService.AddRangeOfEvents(listOfEvents);
            Stage expected = stageService.FindStageById(1);
            //Act
            var result = raportService.CreateRaport(eventsService);
            //Assert
            result.StrongSideStage.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void CreateRaport_ReturnsCorrectSecondStrongSide()
        {
            //Arrange
            var raportService = new RaportService();
            var eventsService = new EventService();
            var eventsForTest = new EventsForTest();
            var stageService = new StageService();
            var listOfEvents = eventsForTest.TestEvents();
            eventsService.AddRangeOfEvents(listOfEvents);
            Stage expected = stageService.FindStageById(2);
            //Act
            var result = raportService.CreateRaport(eventsService);
            //Assert
            result.SecondStrongSideStage.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void CreateRaport_ReturnsCorrectStageToImprove()
        {
            //Arrange
            var raportService = new RaportService();
            var eventsService = new EventService();
            var eventsForTest = new EventsForTest();
            var stageService = new StageService();
            var listOfEvents = eventsForTest.TestEvents();
            eventsService.AddRangeOfEvents(listOfEvents);
            Stage expected = stageService.FindStageById(3);
            //Act
            var result = raportService.CreateRaport(eventsService);
            //Assert
            result.StageToImprove.Should().BeEquivalentTo(expected);
        }
    }
}
