//using System;
using AngerDiary.App.Common;
using AngerDiary.Domain.Entity;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach(var menuAction in Items)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
        private void Initialize()
        {
            AddItem(new MenuAction( 1, "Add new event", "Main" ));
            AddItem(new MenuAction(2, "See events from the past", "Main"));
            AddItem(new MenuAction(3, "See your progess", "Main"));
            AddItem(new MenuAction(4, "Coping Methods", "Main"));

            AddItem(new MenuAction(1, "View the last 7 events", "EventView"));
            AddItem(new MenuAction(2, "View events from the last month", "EventView"));
            AddItem(new MenuAction(3, "View events from chosen month", "EventView"));
            AddItem(new MenuAction(4, "View events from chosen period", "EventView"));
            
        }
    }
}
