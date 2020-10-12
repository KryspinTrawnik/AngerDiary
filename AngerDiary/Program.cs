using System;
using System.Globalization;
namespace AngerDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            //// przywitanie
            /// a dodanie nowej sytuacji
            /// b wczytanie sytuacji
            /// c sprawdzienie postepu
            /// d sposoby radzenia sobie ze zloscia
            ///// a1 poproszenie o czas i date wydarzenia
            ///// a2 poproszenie szczegoly wydarzenia
            ///// b1 prosba o date wydarzenia 
            ///// b2 wybranie czasu 
            ///// b3 edycja??
            ///// c1 zapytanie o przedzial tydzien/ 2tyg/msc/ kwartal/ rok
            ///// c2 wyswietlenie sredniej natezenia , najczesciej stosowana metoda, inne

            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            EventManager eventManeger = new EventManager();
            EventService eventService = new EventService();
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
            return actionService;

        }
    }
}
