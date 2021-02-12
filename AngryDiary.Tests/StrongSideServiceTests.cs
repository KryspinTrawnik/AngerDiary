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
            var
            var strongSideItems = new StrongSideItems();
            var eventService = new EventService();
            var eventsForTests = new EventsForTest();
            var TestEvents = eventsForTests.TestEvents();
            eventService.AddTestEvents(TestEvents);
            //Act
            strongSideItems = 
            //Assert
        }
    }
}
