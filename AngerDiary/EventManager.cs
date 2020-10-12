using System;
using System.Collections.Generic;
using System.Linq;

namespace AngerDiary
{
    public class EventManager
    {
        private Event _event;
        public EventManager()
        {
            _event = new Event();
        }

        public Event Menage()
        {
            AddNewEventDate();
            AddNewEventDescribtion();
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
                Console.WriteLine("Please, enter date and time of a new event");
                Console.WriteLine("Please, use format YYYY/MM/DD HH:MM  (Time needs to be in 24Hrs format)");
                string giventime = Console.ReadLine();
                checksucessful = DateTime.TryParse(giventime, out timeofevent);
            }
            while (!checksucessful);
            _event.Timeofevent = timeofevent;
        }

        public void AddNewEventDescribtion()
        {
            Console.WriteLine("Describe the event:");
            string description = Console.ReadLine();
            _event.Description = description;

            Console.WriteLine("What were your external triggers");
            _event.Externaltriggers = Console.ReadLine();
            Console.WriteLine("What were your intternal triggers");
            _event.Internaltriggers = Console.ReadLine();
            bool checksucessful;
            int angerlevel;
            do
            {
                Console.WriteLine("How angry were you in scale 0 to 10");
                string givenangerlevel = Console.ReadLine();
                checksucessful = Int32.TryParse(givenangerlevel, out angerlevel);
                _event.Angerlevel = angerlevel;
                if (angerlevel > 10 || angerlevel < 0)
                {
                    Console.WriteLine("Anger level needs to be between 0 and 10");
                }
            }
            while (!((angerlevel < 10 && angerlevel > 0 )&& checksucessful));
        }

        public void AddNewEventSignals()
        {
            AngerSignalService angersignalService = new AngerSignalService();
            angersignalService = Initialize(angersignalService);
            _event.Angersignals = new List<AngerSignal>();
            bool exit = true;
            List<int> usedoperation = new List<int>();
            
            do
            {
                Console.WriteLine("Choose from below which of signals did you experience");
                Console.WriteLine("When you finishd press 0");
                var angerSignals = angersignalService.AddNotUsedSignal();
                foreach (var signal in angerSignals)
                {
                    Console.WriteLine($"{signal.Signalid}. {signal.Signalname}.");
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
                    
                    if (testoperation > 10 || testoperation < 0 || checksucessful == false )
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
                        notusedoperation =  true;
                        operation = testoperation;
                    }
                } while (!(checksucessful && notusedoperation));
                
                switch (operation)
                {
                    case 1:
                        _event.Angersignals.Add(new AngerSignal { Signalid = 1, Signalname = "Raised voice", HasBeenUsed = true });
                        angerSignals.Find(p => p.Signalid == 1).HasBeenUsed = true;
                        break;
                    case 2:
                        _event.Angersignals.Add(new AngerSignal { Signalid = 2, Signalname = "Headaches", HasBeenUsed = true });
                        angerSignals.Find(p => p.Signalid == 2).HasBeenUsed = true;
                        break;
                    case 3:
                        _event.Angersignals.Add(new AngerSignal { Signalid = 3, Signalname = "Stomachaches", HasBeenUsed = true });
                        angerSignals.Find(p => p.Signalid == 3).HasBeenUsed = true;
                        break;
                    case 4:
                        _event.Angersignals.Add(new AngerSignal { Signalid = 4, Signalname = "Increased heart rate", HasBeenUsed = true });
                        angerSignals.Find(p => p.Signalid == 4).HasBeenUsed = true;
                        break;
                    case 5:
                        _event.Angersignals.Add(new AngerSignal { Signalid = 5, Signalname = "Raised blood pressure", HasBeenUsed = true });
                        angerSignals.Find(p => p.Signalid == 5).HasBeenUsed = true;
                        break;
                    case 6:
                        _event.Angersignals.Add(new AngerSignal { Signalid = 6, Signalname = "Clenching your jaws or grinding your teeth", HasBeenUsed = true });
                        angerSignals.Find(p => p.Signalid == 6).HasBeenUsed = true;
                        break;
                    case 7:
                        _event.Angersignals.Add(new AngerSignal { Signalid = 7, Signalname = "Clinched fists", HasBeenUsed = true });
                        angerSignals.Find(p => p.Signalid == 7).HasBeenUsed = true;
                        break;
                    case 8:
                        _event.Angersignals.Add(new AngerSignal { Signalid = 8, Signalname = "Sweating, especially your palms", HasBeenUsed = true });
                        angerSignals.Find(p => p.Signalid == 8).HasBeenUsed = true;
                        break;
                    case 9:
                        _event.Angersignals.Add(new AngerSignal { Signalid = 9, Signalname = "Feeling hot in the neck/face", HasBeenUsed = true });
                        angerSignals.Find(p => p.Signalid == 9).HasBeenUsed = true;
                        break;
                    case 0:
                        double avaregeusedoperation = usedoperation.Average();
                        if (avaregeusedoperation == 0)
                        {
                            Console.WriteLine("You need to use at least one signal");
                        }
                        else
                        {
                            usedoperation.Clear();
                            exit = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Your request does not exist");
                        break;
                }

            
            } while (!(exit == false));

        }
        
        private static AngerSignalService Initialize(AngerSignalService angersignalService)
        {
            angersignalService.AddNewSignal(1, "Raised voice", false);
            angersignalService.AddNewSignal(2, "Headaches", false);
            angersignalService.AddNewSignal(3, "Stomachaches", false);
            angersignalService.AddNewSignal(4, "Increased heart rate", false);
            angersignalService.AddNewSignal(5, "Raised blood pressure", false);
            angersignalService.AddNewSignal(6, "Clenching your jaws or grinding your teeth", false);
            angersignalService.AddNewSignal(7, "Clinched fists", false);
            angersignalService.AddNewSignal(8, "Sweating, especially your palms", false);
            angersignalService.AddNewSignal(9, "Feeling hot in the neck/face", false);

            return angersignalService;
        }
        public void AddNewEventReducer()
        {
            ReducerService reducerService = new ReducerService();
           reducerService = ReducerInitialize(reducerService);
            _event.Reducers = new List<Reducer>();
            bool exit = true;
            List<int> usedoperation = new List<int>();
            do
            {
                Console.WriteLine("Choose from below which of reducers did you used");
                Console.WriteLine("When you finishd press 0");
                var reducers = reducerService.AddNotUsedReducer();
                foreach (var reducer in reducers)
                {
                    Console.WriteLine($"{reducer.reducerId}. {reducer.reducerName}.");
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
                switch (operation)
                {
                    case 1:
                        _event.Reducers.Add(new Reducer { reducerId = 1, reducerName = "Raised voice", hasBeenUsed = true });
                        reducers.Find(p => p.reducerId == 1).hasBeenUsed = true;
                        break;
                    case 2:
                        _event.Reducers.Add(new Reducer { reducerId = 2, reducerName = "Deep breathing", hasBeenUsed = true });
                        reducers.Find(p => p.reducerId == 2).hasBeenUsed = true;
                        break;
                    case 3:
                        _event.Reducers.Add(new Reducer { reducerId = 3, reducerName = "Thinking ahead (if - consequences)", hasBeenUsed = true });
                        reducers.Find(p => p.reducerId == 3).hasBeenUsed = true;
                        break;
                    case 4:
                        _event.Reducers.Add(new Reducer { reducerId = 4, reducerName = "Positive visualisation", hasBeenUsed = true });
                        reducers.Find(p => p.reducerId == 4).hasBeenUsed = true;
                        break;
                    case 0:
                        double avaregeusedoperation = usedoperation.Average();
                        if (avaregeusedoperation == 0)
                        {
                            Console.WriteLine("You need to use at least one reducer");
                        }
                        else
                        {
                            usedoperation.Clear();
                            exit = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Your request does not exist");
                        break;
                }

            } while (!(exit == false));
        }
         private static ReducerService ReducerInitialize(ReducerService reducerService)
        {
            reducerService.AddNewReducer(1, "Counting backward", false);
            reducerService.AddNewReducer(2, "Deep breathing", false);
            reducerService.AddNewReducer(3, "Thinking ahead (if - consequences)", false);
            reducerService.AddNewReducer(4, "Positive visualisation", false);
            return reducerService;
        }
        public void AddNewEventSelfInstruction()
        {
            Console.WriteLine("What was your self-instruction thoughts?");
            _event.Selfinstruction = Console.ReadLine();
        }

        public void AddNewEventConsequences()
        {
            Console.WriteLine("What were positive or negative cosnequences of your behaviour?");
            _event.Consequences = Console.ReadLine();
        }
        public void AddNewEventSelfEvaluation()
        {
            StageService stageService = new StageService();
            stageService = StageInitialize(stageService);
            _event.Selfevaluation = new List<Stage>();
            bool exit = true;
            List<int> usedoperation = new List<int>();
            
            do
            {
                Console.WriteLine("With which stages have you done well? Choose from below");
                Console.WriteLine("When you finishd press 0");
                var stages = stageService.AddNotUsedStage();
                foreach (var stage in stages)
                {
                    Console.WriteLine($"{stage.StageId}. {stage.StageName}.");
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
                switch (operation)
                {
                    case 1:
                        _event.Selfevaluation.Add(new Stage { StageId = 1,StageName = "Recognizing triggers", HasBeenUsed = true });
                        stages.Find(p => p.StageId == 1).HasBeenUsed = true;
                        break;
                    case 2:
                        _event.Selfevaluation.Add(new Stage { StageId = 2, StageName = "Recognizing signals of anger", HasBeenUsed = true });
                        stages.Find(p => p.StageId == 2).HasBeenUsed = true;
                        break;
                    case 3:
                        _event.Selfevaluation.Add(new Stage { StageId = 3, StageName = "Using anger reducers", HasBeenUsed = true });
                        stages.Find(p => p.StageId == 3).HasBeenUsed = true;
                        break;
                    case 4:
                        _event.Selfevaluation.Add(new Stage { StageId = 4, StageName = "Self-instruction to keep yourself calm", HasBeenUsed = true });
                        stages.Find(p => p.StageId == 4).HasBeenUsed = true;
                        break;
                    case 5:
                        _event.Selfevaluation.Add(new Stage { StageId = 5, StageName = "Self-rewarding for good effort", HasBeenUsed = true });
                        stages.Find(p => p.StageId == 5).HasBeenUsed = true;
                        break;
                    case 6:
                        _event.Selfevaluation.Add(new Stage { StageId = 6, StageName = "Looking at the good or bad consequences", HasBeenUsed = true });
                        stages.Find(p => p.StageId == 6).HasBeenUsed = true;
                        break;
                    case 0:
                        double avaregeusedoperation = usedoperation.Average();
                        if (avaregeusedoperation == 0)
                        {
                            Console.WriteLine("You need to use at least one stage");
                        }
                        else
                        {
                            usedoperation.Clear();
                            exit = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Your request does not exist");
                        break;
                }

            } while (!(exit == false));
        }

        private static StageService StageInitialize(StageService stageService)
        {
            stageService.AddNewStage(1, "Recognizing triggers", false);
            stageService.AddNewStage(2, "Recognizing signals of anger", false);
            stageService.AddNewStage(3, "Using anger reducers", false);
            stageService.AddNewStage(4, "Self-instruction to keep yourself calm", false);
            stageService.AddNewStage(5, "Self-rewarding for good effort", false);
            stageService.AddNewStage(6, "Looking at the good or bad consequences", false);

            return stageService;
        }
        
        public void AddNewEventSelfCoaching()
        {
            Console.WriteLine("What would you improve in your behavior");
            _event.Selfcoaching = Console.ReadLine();
                
        }
    }
}
