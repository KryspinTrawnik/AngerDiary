using System;
using System.Globalization;
namespace AngerDiary
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            /// d sposoby radzenia sobie ze zloscia
           
           
            
            Helpers helpers = new Helpers();
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            EventManager eventManeger = new EventManager();
            EventService eventService = new EventService();
            EventViewManager eventViewManager = new EventViewManager();
            bool exit = false;
            do
            {
                Console.WriteLine("Welcome to Anger Diary");
                Console.WriteLine("Hope you are alright");
                Console.WriteLine("Please let me know what would you like to do");
                Console.WriteLine("When you finished press 5");
                Console.WriteLine();
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }
                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        var newEvent = eventManeger.Menage();
                        eventService.Add(newEvent);
                        break;
                    case '2':
                        eventViewManager.EventViewMenu(actionService, eventService);
                        break;
                    case '3':
                        if (eventService.Events.Count > 1)
                        {
                            eventService.ViewYourGeneralProgressMenage();
                        }
                        else
                        {
                            Console.WriteLine("There is nothing to show please come back when you add at least 2 events");
                        }
                            break;
                    case '4':
                        break;
                    case '5':
                        exit = true;
                        break;
                    case '6':
                        var testevents = helpers.TestEvents(); //Creating events for testing
                        eventService.AddTestEvents(testevents);
                        break;
                    default:
                        Console.WriteLine("Your request does not exist");
                        break;

                }
            } while (exit == false);
         }   
        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add new event", "Main");
            actionService.AddNewAction(2, "See events from the past", "Main");
            actionService.AddNewAction(3, "See your progess", "Main");
            actionService.AddNewAction(4, "Coping Methods", "Main");

            actionService.AddNewAction(1, "View the last 7 events", "EventView");
            actionService.AddNewAction(2, "View events from the last month", "EventView");
            actionService.AddNewAction(3, "View events from chosen month", "EventView");
            actionService.AddNewAction(4, "View events from chosen period", "EventView");
            return actionService;

        }
    }
}
