using AngerDiary.App.Concrete;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AngryDiary.Tests
{
    public class FileServiceTests
    {
        [Fact] 
        public void ReadQuestions_IsNotNull()
        {
            //Arrange
            var fileService = new FileService();
            var result = new List<string>();
            //Act
            result = fileService.ReadQuestions();
            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void ReadQuestions_WithoutQuotationMarks()
        {
            //Arrange
            var fileService = new FileService();
            var result = new List<string>();
            //Act
            result = fileService.ReadQuestions();
            //Assert
            result.FindAll(x => x.Contains('"')).Should().BeEmpty();
        }
    }
}
