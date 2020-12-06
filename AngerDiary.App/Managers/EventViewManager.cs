using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AngerDiary.App.Managers
{
    public class EventViewManager
    {
        public void EventViewMenu(MenuActionService actionService, EventService eventService)
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
                    ViewLast7Events(eventService);
                    break;
                case '2':
                    ViewEventsFromLastMonth(eventService);
                    break;
                case '3':
                    ViewEventsFromChosenMonth(eventService);
                    break;
                case '4':
                    ViewEventsFromChosenDate(eventService);
                    break;

                default:
                    Console.WriteLine("Requested operation does not exist");
                    break;
            }
        }



        public void ViewLast7Events(EventService eventService)
        {

            bool exit = false;
            int operation = 0;
            int testoperation = 0;
            bool checksucessful;
            int start = 0;
            List<Event> eventsToView = new List<Event>();

            if (eventService.Events.Count > 7)
            {
                start = eventService.Events.Count - 7;
            }
            for (int i = start; eventService.Events.Count > i; i++)
            {
                eventsToView.Add(eventService.Events[i]);
                eventsToView[i].Id = eventsToView.Count;
            }
            do
            {
                do
                {
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
                        exit = true;
                    }
                    else
                    {
                        operation = testoperation;
                        EventToView(eventsToView.Find(x => x.Id == operation));
                    }
                } while (!checksucessful);

            } while (!(exit == true));
        }

        public void ViewEventsFromLastMonth(EventService eventService)
        {
            bool exit = false;
            int operation = 0;
            int testoperation = 0;
            bool checksucessful;
            DateTime today = DateTime.Now;
            DateTime monthEarlier = today.AddMonths(-1);
            int result;
            List<Event> eventsToView = new List<Event>();
            for (int i = 0; eventService.Events.Count > i; i++)
            {
                result = DateTime.Compare(monthEarlier, eventService.Events[i].TimeOfEvent);
                if (result <= 0)
                {
                    eventsToView.Add(eventService.Events[i]);
                    eventsToView[(eventsToView.Count - 1)].Id = eventsToView.Count;

                }
            }
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
                        EventToView(eventsToView.Find(x => x.Id == operation));
                    }
                } while (!checksucessful);
            } while (!(exit == true));

        }
        public void ViewEventsFromChosenMonth(EventService eventService)
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
                    List<Event> eventsToView = new List<Event>(eventService.Events.FindAll(p => p.TimeOfEvent.Month == givenMonth.Month && p.TimeOfEvent.Year == givenMonth.Year));
                    do
                    {
                        if (eventsToView.Count > 0)
                        {
                            foreach (Event @event in eventsToView)
                            {
                                @event.Id = (eventsToView.LastIndexOf(@event) + 1);
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
                                EventToView(eventsToView.Find(x => x.Id == operation));
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

        public void ViewEventsFromChosenDate(EventService eventService)
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
                    List<Event> eventsToView = new List<Event>(eventService.Events.FindAll(p =>  p.TimeOfEvent.Date == givenDate.Date));
                    do
                    {
                        if (eventsToView.Count > 0)
                        {
                            foreach (Event @event in eventsToView)
                            {
                                @event.Id = (eventsToView.LastIndexOf(@event) + 1);
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
                                EventToView(eventsToView.Find(x => x.Id == operation));
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
        public void EventToView(Event eventToView)
        {

            Console.WriteLine("Time of the event is:");
            Console.WriteLine($"{eventToView.TimeOfEvent}");
            Console.WriteLine("Anger level from the event is:");
            Console.WriteLine($"{eventToView.AngerLevel}");
            Console.WriteLine("Description of the event is:");
            Console.WriteLine($"{eventToView.Description}");
            Console.WriteLine("Internal triggers from the event are:");
            Console.WriteLine($"{eventToView.InternalTriggers}");
            Console.WriteLine("External triggers from the event are:");
            Console.WriteLine($"{eventToView.ExternalTriggers}");
            Console.WriteLine("Anger signals of the event are:");
            foreach (AngerSignal angerSignal in eventToView.AngerSignals)
            {
                Console.WriteLine(angerSignal.Name);
            }
            Console.WriteLine("Reducers used in the event are:");
            foreach (Reducer reducer in eventToView.Reducers)
            {
                Console.WriteLine(reducer.Name);
            }
            Console.WriteLine("Self-instructions from the event is:");
            Console.WriteLine($"{eventToView.SelfInstruction}");
            Console.WriteLine("Consequences from the event are:");
            Console.WriteLine($"{eventToView.Consequences}");
            Console.WriteLine("On these stages you did well during the event:");
            foreach (Stage stage in eventToView.SelfEvaluation)
            {
                Console.WriteLine(stage.Name);
            }
            Console.WriteLine("These are your self-coaching thoughts:");
            Console.WriteLine($"{eventToView.SelfCoaching}");
        }
    }
    
}

    

        
        
           
    



