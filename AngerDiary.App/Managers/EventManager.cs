﻿using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngerDiary.App.Managers

{
    public class EventManager
    {
        private Event _event;
        public EventManager()
        {
            _event = new Event();
        }

        public Event Menage(EventService eventService)
        {
            Event newEvent = new Event();
            var @event = eventService.AddId(newEvent);
            AddNewEventDate(@event);
            AddNewEventDescribtion(@event);
            AddNewEventSignals(@event);
            AddNewEventReducer(@event);
            AddNewEventSelfInstruction(@event);
            AddNewEventConsequences(@event);
            AddNewEventSelfEvaluation(@event);
            AddNewEventSelfCoaching(@event);

            return @event;
        }

        public void AddNewEventDate(Event @event)
        {

            DateTime timeofevent;
            bool checksucessful;
            do
            {
                Console.WriteLine("Please, enter date and time of a new event");
                Console.WriteLine("Please, use format YYYY/MM/DD HH:MM  (Time needs to be in 24Hrs format)");
                Console.WriteLine();
                string giventime = Console.ReadLine();
                checksucessful = DateTime.TryParse(giventime, out timeofevent);
            }
            while (!checksucessful);
            @event.TimeOfEvent = timeofevent;
        }

        public void AddNewEventDescribtion(Event @event)
        {
            Console.WriteLine("Describe the event:");
            Console.WriteLine();
            string description = Console.ReadLine();
            @event.Description = description;

            Console.WriteLine("What were your external triggers");
            Console.WriteLine();
            @event.ExternalTriggers = Console.ReadLine();
            Console.WriteLine("What were your intternal triggers");
            Console.WriteLine();
            @event.InternalTriggers = Console.ReadLine();
            bool checksucessful;
            int angerlevel;
            do
            {
                Console.WriteLine("How angry were you in scale 0 to 10");
                Console.WriteLine();
                string givenangerlevel = Console.ReadLine();
                checksucessful = Int32.TryParse(givenangerlevel, out angerlevel);
                @event.AngerLevel = angerlevel;
                if (angerlevel > 10 || angerlevel < 0)
                {
                    Console.WriteLine("Anger level needs to be between 0 and 10");
                }
            }
            while (!((angerlevel < 10 && angerlevel > 0) && checksucessful));
        }

        public void AddNewEventSignals(Event @event)
        {
            AngerSignalService angersignalService = new AngerSignalService();
            @event.AngerSignals = new List<AngerSignal>();
            bool exit = false;
            List<int> usedoperation = new List<int>();

            do
            {
                Console.WriteLine("Choose from below which of signals did you experience");
                Console.WriteLine("When you finishd press 0");
                Console.WriteLine();
                var angerSignals = angersignalService.AddNotUsedSignal();
                foreach (var signal in angerSignals)
                {
                    Console.WriteLine($"{signal.Id}. {signal.Name}.");
                }
                int operation = 0;
                int testoperation = 0;
                bool checksucessful;
                bool notusedoperation;

                do
                {
                    string givenoperation = Console.ReadLine();
                    checksucessful = Int32.TryParse(givenoperation, out testoperation);
                    notusedoperation = true;
                    if (givenoperation != "0")
                    {
                        usedoperation.Add(testoperation);
                    }

                    if (testoperation > 10 || testoperation < 0 || checksucessful == false)
                    {
                        Console.WriteLine("Chosen id needs to be a number between 0 and 9");
                    }
                    else if (usedoperation.FindAll(p => p == testoperation).Count > 1 && givenoperation != "0")
                    {
                        Console.WriteLine("Chosen signal has already been used please choose another one or press 0 to finish");
                        notusedoperation = false;
                    }
                    else
                    {
                        notusedoperation = true;
                        operation = testoperation;
                    }
                } while (!(checksucessful && notusedoperation));
                if (operation != 0)
                {
                    angerSignals.Find(p => p.Id == operation).HasBeenUsed = true;
                    @event.AngerSignals.Add(angerSignals.Find(x => x.Id == operation));
                }
                else if (operation == 0)
                {
                    double avaregeusedoperation = usedoperation.Average();
                    if (avaregeusedoperation == 0)
                    {
                        Console.WriteLine("You need to use at least one signal");
                    }
                    else
                    {
                        usedoperation.Clear();
                        exit = true;
                    }
                }
                else
                {
                    Console.WriteLine("Your request does not exist");

                }
            } while (!(exit == true));

        }

        public void AddNewEventReducer(Event @event)
        {
            ReducerService reducerService = new ReducerService();
            @event.Reducers = new List<Reducer>();
            bool exit = false;
            List<int> usedoperation = new List<int>();
            do
            {
                Console.WriteLine("Choose from below which of reducers did you used");
                Console.WriteLine("When you finishd press 0");
                Console.WriteLine();
                var reducers = reducerService.GetNotUsedReducer();
                foreach (var reducer in reducers)
                {
                    Console.WriteLine($"{reducer.Id}. {reducer.Name}.");
                }
                int operation = 0;
                int testoperation = 0;
                bool checksucessful;
                bool notusedoperation;
                do
                {
                    string givenoperation = Console.ReadLine();
                    checksucessful = Int32.TryParse(givenoperation, out testoperation);
                    notusedoperation = true;
                    if (givenoperation != "0")
                    {
                        usedoperation.Add(testoperation);
                    }

                    if (testoperation > 4 || testoperation < 0 || checksucessful == false)
                    {
                        Console.WriteLine("Chosen id needs to be a number between 0 and 4");
                    }
                    else if (usedoperation.FindAll(p => p == testoperation).Count > 1 && givenoperation != "0")
                    {
                        Console.WriteLine("Chosen signal has already been used please choose another one or press 0 to finish");
                        notusedoperation = false;
                    }
                    else
                    {
                        notusedoperation = true;
                        operation = testoperation;
                    }
                } while (!(checksucessful && notusedoperation));
                if (operation != 0)
                {
                    reducers.Find(p => p.Id == operation).hasBeenUsed = true;
                    @event.Reducers.Add(reducers.Find(p => p.Id == operation));

                }
                else if (operation == 0)
                {
                    double avaregeusedoperation = usedoperation.Average();
                    if (avaregeusedoperation == 0)
                    {
                        Console.WriteLine("You need to use at least one reducer");
                    }
                    else
                    {
                        usedoperation.Clear();
                        exit = true;
                    }
                }
                else
                {
                    Console.WriteLine("Your request does not exist");
                }

            } while (!(exit == true));
        }

        public void AddNewEventSelfInstruction(Event @event)
        {
            Console.WriteLine("What was your self-instruction thoughts?");
            @event.SelfInstruction = Console.ReadLine();
        }

        public void AddNewEventConsequences(Event @event)
        {
            Console.WriteLine("What were positive or negative cosnequences of your behaviour?");
            Console.WriteLine();
            @event.Consequences = Console.ReadLine();
        }

        public void AddNewEventSelfEvaluation(Event @event)
        {
            StageService stageService = new StageService();
            @event.SelfEvaluation = new List<Stage>();
            bool exit = false;
            List<int> usedoperation = new List<int>();

            do
            {
                Console.WriteLine("With which stages have you done well? Choose from below");
                Console.WriteLine("When you finishd press 0");
                Console.WriteLine();
                var stages = stageService.AddNotUsedStage();
                foreach (var stage in stages)
                {
                    Console.WriteLine($"{stage.Id}. {stage.Name}.");
                }
                int operation = 0;
                int testoperation = 0;
                bool checksucessful;
                bool notusedoperation;
                do
                {
                    string givenoperation = Console.ReadLine();
                    checksucessful = Int32.TryParse(givenoperation, out testoperation);
                    notusedoperation = false;
                    if (givenoperation != "0")
                    {
                        usedoperation.Add(testoperation);
                    }
                    if (testoperation > 6 || testoperation < 0 || checksucessful == false)
                    {
                        Console.WriteLine("Chosen id needs to be a number between 0 and 6");
                    }
                    else if (usedoperation.FindAll(p => p == testoperation).Count > 1)
                    {
                        Console.WriteLine("Chosen option has already been used please choose another one or press 0 to finish");
                        notusedoperation = false;
                    }
                    else
                    {
                        notusedoperation = true;
                        operation = testoperation;
                    }
                } while (!(checksucessful && notusedoperation));
                if (operation != 0)
                {
                    stages.Find(p => p.Id == operation).HasBeenUsed = true;
                    @event.SelfEvaluation.Add(stages.Find(p => p.Id == operation));
                }
                else if (operation == 0)
                {
                    double avaregeusedoperation = usedoperation.Average();
                    if (avaregeusedoperation == 0)
                    {
                        Console.WriteLine("You need to use at least one stage");
                    }
                    else
                    {
                        usedoperation.Clear();
                        exit = true;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Your request does not exist");
                }

            } while (!(exit == true));
        }

        public void AddNewEventSelfCoaching(Event @event)
        {
            Console.WriteLine("What would you improve in your behavior");
            Console.WriteLine();
            @event.SelfCoaching = Console.ReadLine();
        }
    }
}
