using System;
using Xunit;
using AngryDiary;
using Moq;
using FluentAssertions;
using AngerDiary.App.Abstract;
using AngerDiary.Domain.Entity;
using AngerDiary.App.Concrete;
using System.Collections.Generic;

namespace AngryDiary.Tests
{  
    public class AngerSignalServiceTest
    {
        [Fact]
        public void ReturnNotUsedSignaltTest_WhenNoEmptyReturnUnused()
        {
            //Arrange
            var angerSignalService = new AngerSignalService();
            angerSignalService.Items[1].HasBeenUsed = true;

            //Act
            var result = angerSignalService.ReturnNotUsedSignal();

            //Assert
            result.Should().NotBeEmpty();
            result.Count.Should().Be(8);
        }
        [Fact]
        public void ReturnNotUsedSignal_ReturnEmpty()
        {
            //Arrange
            var angerSignalService = new AngerSignalService();
            angerSignalService.Items.ForEach(s => s.HasBeenUsed = true );

            //Act
            var result = angerSignalService.ReturnNotUsedSignal();

            //Assert
            result.Should().BeEmpty();
        }
    }

}
