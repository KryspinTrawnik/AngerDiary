using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;

namespace AngerDiary.App.Managers

{
    public class EventManager 
    {
        private readonly Event _event;
        private readonly AngerSignalService angerSignalService;
        private readonly ReducerService reducerService;
        private readonly StageService stageService;
        private List<string> Questions;

        public EventManager()
        {
            _event = new Event();
            angerSignalService = new AngerSignalService();
            reducerService = new ReducerService();
            stageService = new StageService();

        }

        public Event Menage(EventService eventService, FileService fileService)
        {
            Questions = fileService.ReadQuestions();
            _event.Id = eventService.AddId();
            AddNewEventDate();
            AddNewEventDescription();
            AddNewEventSignals();
            AddNewEventReducer();
            AddNewEventSelfInstruction();
            AddNewEventConsequences();
            AddNewEventSelfEvaluation();
            AddNewEventSelfCoaching();
            
            return _event;
        }
       
        public void AddNewEventDate()
        {

            DateTime timeofevent;
            bool checksucessful;
            do
            {
                Console.WriteLine(Questions[0]);
                Console.WriteLine(Questions[1]);
                Console.WriteLine();
                string giventime = Console.ReadLine();
                checksucessful = DateTime.TryParse(giventime, out timeofevent);
            }
            while (!checksucessful);
            _event.TimeOfEvent = timeofevent;
        }

        public void AddNewEventDescription()
        {
            Console.WriteLine(Questions[2]);
            Console.WriteLine();
            string description = Console.ReadLine();
            _event.Description = description;

            Console.WriteLine(Questions[3]);
            Console.WriteLine();
            _event.ExternalTriggers = Console.ReadLine();
            Console.WriteLine(Questions[4]);
            Console.WriteLine();
            _event.InternalTriggers = Console.ReadLine();
            bool checksucessful;
            int angerlevel;
            do
            {
                Console.WriteLine(Questions[5]);
                Console.WriteLine();
                string givenangerlevel = Console.ReadLine();
                checksucessful = Int32.TryParse(givenangerlevel, out angerlevel);
                _event.AngerLevel = angerlevel;
                if (angerlevel > 10 || angerlevel < 0)
                {
                    Console.WriteLine(Questions[6]);
                }
            }
            while (!((angerlevel <= 10 && angerlevel >= 0) && checksucessful));
        }

        public void AddNewEventSignals()
        {
            Console.Clear();
            _event.AngerSignals = new List<AngerSignal>();
            bool exit = false;
            List<int> usedoperation = new List<int>();

            do
            {
                Console.WriteLine(Questions[7]);
                Console.WriteLine(Questions[8]);
                Console.WriteLine();
                var angerSignals = angerSignalService.ReturnNotUsedSignal();
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
                        Console.WriteLine(Questions[9]);
                    }
                    else if (usedoperation.FindAll(p => p == testoperation).Count > 1 && givenoperation != "0")
                    {
                        Console.WriteLine(Questions[10]);
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
                    _event.AngerSignals.Add(angerSignals.Find(x => x.Id == operation));
                }
                else if (operation == 0)
                {
                   
                    if (usedoperation.Count == 0)
                    {
                        Console.WriteLine(Questions[11]);
                    }
                    else
                    {
                        usedoperation.Clear();
                        exit = true;
                    }
                }
                else
                {
                    Console.WriteLine(Questions[12]);

                }
            } while (!(exit == true));

        }

        public void AddNewEventReducer()
        {
            _event.Reducers = new List<Reducer>();
            bool exit = false;
            List<int> usedoperation = new List<int>();
            do
            {
                Console.WriteLine(Questions[13]);
                Console.WriteLine(Questions[14]);
                Console.WriteLine(Questions[15]);
                Console.WriteLine();
                var reducers = reducerService.GetNotUsedReducers();
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
                        Console.WriteLine(Questions[16]);
                    }
                    else if (usedoperation.FindAll(p => p == testoperation).Count > 1 && givenoperation != "0")
                    {
                        Console.WriteLine(Questions[17]);
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
                    reducers.Find(p => p.Id == operation).HasBeenUsed = true;
                    _event.Reducers.Add(reducers.Find(p => p.Id == operation));

                }
                else if (operation == 0)
                {
                    if (usedoperation.Count == 0)
                    {
                        Console.WriteLine(Questions[17]);
                    }
                    else
                    {
                        usedoperation.Clear();
                        exit = true;
                    }
                }
                else
                {
                    Console.WriteLine(Questions[18]);
                }

            } while (!(exit == true));
        }
        public void AddNewEventSelfInstruction()
        {
            Console.Clear();
            Console.WriteLine(Questions[19]);
            _event.SelfInstruction = Console.ReadLine();
        }

        public void AddNewEventConsequences()
        {
            Console.WriteLine(Questions[20]);
            Console.WriteLine();
            _event.Consequences = Console.ReadLine();
        }

        public void AddNewEventSelfEvaluation()
        {
           
            _event.SelfEvaluation = new List<Stage>();
            bool exit = false;
            List<int> usedoperation = new List<int>();

            do
            {
                Console.WriteLine(Questions[21]);
                Console.WriteLine(Questions[22]);
                Console.WriteLine();
                var stages = stageService.GetNotUsedStage();
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
                        Console.WriteLine(Questions[23]);
                    }
                    else if (usedoperation.FindAll(p => p == testoperation).Count > 1)
                    {
                        Console.WriteLine(Questions[24]);
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
                    _event.SelfEvaluation.Add(stages.Find(p => p.Id == operation));
                }
                else if (operation == 0)
                {
                    if (usedoperation.Count == 0)
                    {
                        Console.WriteLine(Questions[25]);
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
                    Console.WriteLine(Questions[26]);
                }

            } while (!(exit == true));
        }

        public void AddNewEventSelfCoaching()
        {
            Console.WriteLine(Questions[27]);
            Console.WriteLine();
            _event.SelfCoaching = Console.ReadLine();
            Console.Clear();
        }
    }
}
