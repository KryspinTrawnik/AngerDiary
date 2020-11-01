using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    class EventViewManager
    {
       

        public void EventViewMenu(MenuActionService actionService)
        {
            EventService eventService = new EventService();
            Console.WriteLine("Please, choose which list would you like to explore");
            var mainMenu = actionService.GetMenuActionsByMenuName("EventView");
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
            }
            var operation = Console.ReadKey();
             switch (operation.KeyChar)
             {
                case '1':
                    eventService.ViewLast7Events();
                    break;
                case '2':

                    break;
                case '3':

                    break;
                case '4':

                    break;
                
                default:
                    Console.WriteLine("Requested operation does not exist");
                    break;   
             }
        }
        
               
           
        
    }
}

