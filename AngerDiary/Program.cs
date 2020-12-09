using AngerDiary.App.Concrete;
using AngerDiary.App.Managers;
using AngerDiary.Helpers;
using System;
namespace AngerDiary
{
    class Program
    {
        static void Main(string[] args)
        {


            /// d sposoby radzenia sobie ze zloscia

            MenuActionService actionService = new MenuActionService();
            EventService eventService = new EventService();
            var helpers = new Helper();
            EventManager eventManeger = new EventManager();
            EventViewManager eventViewManager = new EventViewManager();
            EventProgressManager eventProgressManager = new EventProgressManager();
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
                        var newEvent = eventManeger.Menage(eventService);
                        eventService.AddItem(newEvent);
                        break;
                    case '2':
                        eventViewManager.EventViewMenu(actionService, eventService);
                        break;
                    case '3':
                        if (eventService.Items.Count > 1)
                        {
                            eventProgressManager.Menage(eventService);
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

    }
}
