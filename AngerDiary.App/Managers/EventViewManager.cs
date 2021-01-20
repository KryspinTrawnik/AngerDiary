using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;

namespace AngerDiary.App.Managers
{
    public class EventViewManager
    {
        private ViewEvent viewEvent;
        private EventService eventService;
        private View7LastEvents view7LastEvents;
        private ViewEventsLastMonth viewEventsLastMonth;
        public EventViewManager(EventService eventService)
        {
            view7LastEvents = new View7LastEvents();
            viewEventsLastMonth = new ViewEventsLastMonth();
            viewEvent = new ViewEvent();
            this.eventService = eventService;
        }
        public void EventViewMenu(MenuActionService actionService)
        {
            Console.WriteLine();
            Console.WriteLine("Please, choose which list would you like to explore");
            var mainMenu = actionService.GetMenuActionsByMenuName("EventView");
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
            }
            Console.WriteLine();
            var operation = Console.ReadKey();
            switch (operation.KeyChar)
            {
                case '1':
                    ViewLast7Events();
                    break;
                case '2':
                    ViewEventsFromLastMonth();
                    break;
                case '3':
                    ViewEventsFromChosenMonth();
                    break;
                case '4':
                    ViewEventsFromChosenDate();
                    break;

                default:
                    Console.WriteLine("Requested operation does not exist");
                    break;
            }
        }



        public void ViewLast7Events()
        {

            bool exit = false;
            int operation = 0;
            int testoperation = 0;
            bool checksucessful;
            List<Event> eventsToView = view7LastEvents.Last7Events(eventService);
            do
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose which event would you like to see");
                    Console.WriteLine("When you finish press 0");
                    foreach (Event _event in eventsToView)
                    {
                        Console.WriteLine($"{_event.Id}. Date: {_event.TimeOfEvent} Anger level was: {_event.AngerLevel}");
                    }
                    Console.WriteLine();
                    string givenoperation = Console.ReadLine();
                    checksucessful = Int32.TryParse(givenoperation, out testoperation);
                    if (testoperation > eventsToView.Count || testoperation < 0 || checksucessful == false)
                    {
                        Console.WriteLine($"Chosen id needs to be a number between 0 and {eventsToView.Count}");
                    }
                    else if (testoperation == 0)
                    {
                        exit = true;
                    }
                    else
                    {
                        operation = testoperation;
                        viewEvent.EventToView(eventsToView.Find(x => x.Id == operation));
                    }
                } while (!checksucessful);

            } while (!(exit == true));
        }

        public void ViewEventsFromLastMonth()
        {
            bool exit = false;
            int operation = 0;
            int testoperation = 0;
            bool checksucessful;
            List<Event> eventsToView = viewEventsLastMonth.ViewLastMonth(eventService);
            do
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose which event would you like to see");
                    Console.WriteLine("When you finish press 0");
                    foreach (Event eventA in eventsToView)
                    {

                        Console.WriteLine($"{eventA.Id}. Date: {eventA.TimeOfEvent} Anger level was: {eventA.AngerLevel}");
                    }
                    Console.WriteLine();
                    string givenoperation = Console.ReadLine();
                    checksucessful = Int32.TryParse(givenoperation, out testoperation);
                    if (testoperation > eventsToView.Count || testoperation < 0 || checksucessful == false)
                    {
                        Console.WriteLine($"Chosen id needs to be a number between 0 and {eventsToView.Count}");
                    }
                    else if (testoperation == 0)
                    {
                        exit = true;
                    }
                    else
                    {
                        operation = testoperation;
                        viewEvent.EventToView(eventsToView.Find(x => x.Id == operation));
                    }
                } while (!checksucessful);
            } while (!(exit == true));

        }
        public void ViewEventsFromChosenMonth()
        {
            DateTime givenMonth;
            bool checksucessful;
            bool exitFromWholeView = false;
            bool exitFromMonthView = false;
            int operation = 0;
            int testoperation = 0;
            do
            {
                do
                {
                    Console.WriteLine("Please, enter a month which you want to explore");
                    Console.WriteLine("Please, use format YYYY/MM");
                    Console.WriteLine("if you want exit press 0 and enter");
                    Console.WriteLine();
                    string giventime = Console.ReadLine();
                    if (giventime == "0")
                    {
                        exitFromWholeView = true;
                        checksucessful = true;
                        givenMonth = DateTime.Today;
                    }
                    else
                    {
                        checksucessful = DateTime.TryParse(giventime, out givenMonth);
                    }
                } while (!checksucessful);


                if (exitFromWholeView == false)
                {
                    List<Event> eventsToView = new List<Event>(eventService.Items.FindAll(p => p.TimeOfEvent.Month == givenMonth.Month && p.TimeOfEvent.Year == givenMonth.Year));
                    do
                    {
                        if (eventsToView.Count > 0)
                        {
                            foreach (Event _event in eventsToView)
                            {
                                _event.Id = (eventsToView.LastIndexOf(_event) + 1);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Choose which event would you like to see");
                            Console.WriteLine("When you finish press 0");
                            foreach (Event _event in eventsToView)
                            {

                                Console.WriteLine($"{_event.Id}. Date: {_event.TimeOfEvent} Anger level was: {_event.AngerLevel}");
                            }
                            Console.WriteLine();
                            string givenoperation = Console.ReadLine();
                            checksucessful = Int32.TryParse(givenoperation, out testoperation);
                            if (testoperation > eventsToView.Count || testoperation < 0 || checksucessful == false)
                            {
                                Console.WriteLine($"Chosen id needs to be a number between 0 and {eventsToView.Count}");
                            }
                            else if (testoperation == 0)
                            {
                                exitFromMonthView = true;
                            }
                            else
                            {
                                operation = testoperation;
                                viewEvent.EventToView(eventsToView.Find(x => x.Id == operation));
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no event to view.");
                            Console.WriteLine("Please enter different month");
                            exitFromMonthView = true;
                        }

                    } while (!(exitFromMonthView == true));
                }
            } while (!(exitFromWholeView == true));
        }

        public void ViewEventsFromChosenDate()
        {
            DateTime givenDate;
            bool checksucessful;
            bool exitFromWholeView = false;
            bool exitFromMonthView = false;
            int operation = 0;
            int testoperation = 0;
            do
            {
                do
                {
                    Console.WriteLine("Please, enter a date which you want to explore");
                    Console.WriteLine("Please, use format YYYY/MM/DD");
                    Console.WriteLine("if you want exit press 0 and enter");
                    Console.WriteLine();
                    string giventime = Console.ReadLine();
                    if (giventime == "0")
                    {
                        exitFromWholeView = true;
                        checksucessful = true;
                        givenDate = DateTime.Today;
                    }
                    else
                    {
                        checksucessful = DateTime.TryParse(giventime, out givenDate);
                    }
                } while (!checksucessful);


                if (exitFromWholeView == false)
                {
                    List<Event> eventsToView = new List<Event>(eventService.Items.FindAll(p => p.TimeOfEvent.Date == givenDate.Date));
                    do
                    {
                        if (eventsToView.Count > 0)
                        {
                            foreach (Event _event in eventsToView)
                            {
                                _event.Id = (eventsToView.LastIndexOf(_event) + 1);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Choose which event would you like to see");
                            Console.WriteLine("When you finish press 0");
                            foreach (Event @event in eventsToView)
                            {

                                Console.WriteLine($"{@event.Id}. Date: {@event.TimeOfEvent} Anger level was: {@event.AngerLevel}");
                            }
                            Console.WriteLine();
                            string givenoperation = Console.ReadLine();
                            checksucessful = Int32.TryParse(givenoperation, out testoperation);
                            if (testoperation > eventsToView.Count || testoperation < 0 || checksucessful == false)
                            {
                                Console.WriteLine($"Chosen id needs to be a number between 0 and {eventsToView.Count}");
                            }
                            else if (testoperation == 0)
                            {
                                exitFromMonthView = true;
                            }
                            else
                            {
                                operation = testoperation;
                                viewEvent.EventToView(eventsToView.Find(x => x.Id == operation));
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no event to view.");
                            Console.WriteLine("Please enter different date");
                            exitFromMonthView = true;
                        }

                    } while (!(exitFromMonthView == true));
                }
            } while (!(exitFromWholeView == true));
        }
   
    }

}










