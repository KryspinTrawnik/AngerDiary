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
    public class MenuActionServiceTest
    {
        [Fact]
        public void GetMenuActionsByMenuName_IsNotNull()
        {
            //Arrange
            var menuActionService = new MenuActionService();
            //Act
            var Result = menuActionService.GetMenuActionsByMenuName("Main");
            //Assert
            Result.Should().NotBeNull();
        }
        [Fact]
        public void GetMenuActionsByMenuName_IsNullWhenEmptyStringGiven()
        {
            //Arrange
            var menuActionService = new MenuActionService();
            //Act
            var Result = menuActionService.GetMenuActionsByMenuName("");
            //Assert
            Result.Should().BeEmpty();
        }
        [Fact]
        public void GetMenuActionsByMenuName_CountIsRight()
        {
            //Arrange
            var menuActionService = new MenuActionService();
            //Act
            var Result = menuActionService.GetMenuActionsByMenuName("Main");
            //Assert
            Result.Count.Should().Be(4);        
        }
        [Theory]
        [InlineData("Main", 1, "Add new event")]
        [InlineData("EventView", 2, "View events from the last month")]
        [InlineData("EventView", 4, "View events from chosen period")]
        [InlineData("Main", 3, "See your progess")]
        public void GetMenuActionsByMenuName_ChangeToViewMenu_ContentCheck(string menuName, int id, string name)
        {
            //Arrange
            var menuActionService = new MenuActionService();
            var expected = new MenuAction(id, name, menuName) { Id = id, Name = name, MenuName = menuName };
                //Act
            var result = menuActionService.GetMenuActionsByMenuName(menuName);
            //Assert
            result.Find(x => x.Id == id).Should().BeSameAs(expected);
        }
    }
}
