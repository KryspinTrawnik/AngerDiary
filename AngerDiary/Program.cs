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
            /// d sposoby radzenia sobie ze zlosc)
            FileService fileService = new FileService();
            MenuActionService actionService = new MenuActionService();
            EventService eventService = new EventService();
            Helper helpers = new Helper();
            EventViewManager eventViewManager = new EventViewManager(eventService);
            EventProgressManager eventProgressManager = new EventProgressManager(eventService);
            RaportService raportService = new RaportService();
            bool exit = false;
            fileService.UploadItems(eventService);
            fileService.UploadRaports(raportService);
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
                        EventManager eventManeger = new EventManager();
                        var newEvent = eventManeger.Menage(eventService, fileService);
                        eventService.AddItem(newEvent);
                        fileService.SaveRaport(eventService, raportService);
                        break;
                    case '2':
                        eventViewManager.EventViewMenu(actionService);
                        break;
                    case '3':
                        if (eventService.Items.Count > 1)
                        {
                            eventProgressManager.Menage();
                        }
                        else
                        {
                            Console.WriteLine("There is nothing to show please come back when you add at least 2 events");
                        }
                        break;
                    case '4':
                        break;
                    case '5':
                        fileService.SavingToFile(eventService);
                        fileService.SaveRaport(eventService, raportService);
                        exit = true;
                        break;
                    case '6':
                        var testevents = helpers.TestEvents(); //Creating events for testing
                        eventService.AddRangeOfEvents(testevents);
                        break;
                    default:
                        Console.WriteLine("Your request does not exist");
                        break;

                }
            } while (exit == false);
        }
    }
}
