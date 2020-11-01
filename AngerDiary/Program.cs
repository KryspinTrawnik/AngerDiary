using System;
using System.Globalization;
namespace AngerDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            /// b wczytanie sytuacji
            /// c sprawdzienie postepu
            /// d sposoby radzenia sobie ze zloscia
            ///// b1 wyswietlanie przedzialu czasu
            ///// b1a ostatnie 7 wydarzen
            ///// b1b ostatni miesiac
            ///// b1c wybrany miesiac
            ///// b1d wbrany okres czasu
            ///// b2 wybranie eventu przez id - wyswietlenie wszystkich wlasciwosci 
            ///// c1 zapytanie o przedzial tydzien/ 2tyg/msc/ kwartal/ rok
            ///// c2 wyswietlenie sredniej natezenia , najczesciej stosowana metoda, inne
            
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
                        eventViewManager.EventViewMenu(actionService);
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        exit = true;
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

            actionService.AddNewAction(1, "See the last event", "EventView");
            actionService.AddNewAction(2, "See events from the last month", "EventView");
            actionService.AddNewAction(3, "See events from chosen month", "EventView");
            actionService.AddNewAction(4, "See events from chosen period", "EventView");
            return actionService;

        }
    }
}
