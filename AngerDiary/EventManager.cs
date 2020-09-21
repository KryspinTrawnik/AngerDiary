using System;
using System.Collections.Generic;

namespace AngerDiary
{
    public class EventManeger
    {
        private Event _event;
        public EventManeger()
        {
            this._event = new Event();
        }
        public EventManeger(Event _event)
        {
            this._event = _event;
        }

        public void Menage(MenuActionService actionService)
        {
            AddNewEventDate();
            AddNewEventDescribtion();
            AddNewEventSignals();
            AddNewEventSummary();
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
            _event.Angersignal = new List<AngerSignal>();
            bool exit = true;
            List<int> chosenId = new List<int>();
            do
            {
                Console.WriteLine("Choose from below which of signals did you experience");
                Console.WriteLine("When you finishd press 0");
                var angerSignals = angersignalService.AddNotUsedSignal();
                for (int i = 0; i < angerSignals.Count  ; i++)
                {
                    Console.WriteLine($"{angerSignals[i].Signalid}. {angerSignals[i].Signalname}.");
                }
                int operation;
                bool checksucessful;
                bool isIdInList;
                do
                {
                    string givenoperation = Console.ReadLine();
                    checksucessful = Int32.TryParse(givenoperation, out operation);
                    if (operation > 10 || operation < 0)
                    {
                        Console.WriteLine("Chosen id needs to be between 0 and 9");
                    }
                    else
                    {
                     chosenId.Find(operation)   
                    }
                }while(!che)

                switch (operation.KeyChar)
                {
                    case '1':
                        _event.Angersignal.Add(new AngerSignal { Signalid = 1, Signalname = "Raised voice", Hasbeenused = true });
                        angerSignals.Find(p => p.Signalid == 1).Hasbeenused = true;
                        break;
                    case '2':
                        _event.Angersignal.Add(new AngerSignal { Signalid = 2, Signalname = "Headaches", Hasbeenused = true });
                        angerSignals.Find(p => p.Signalid == 2).Hasbeenused = true;
                        break;
                    case '3':
                        _event.Angersignal.Add(new AngerSignal { Signalid = 3, Signalname = "Stomachaches", Hasbeenused = true });
                        angerSignals.Find(p => p.Signalid == 3).Hasbeenused = true;
                        break;
                    case '4':
                        _event.Angersignal.Add(new AngerSignal { Signalid = 4, Signalname = "Increased heart rate", Hasbeenused = true });
                        angerSignals.Find(p => p.Signalid == 4).Hasbeenused = true;
                        break;
                    case '5':
                        _event.Angersignal.Add(new AngerSignal { Signalid = 5, Signalname = "Raised blood pressure", Hasbeenused = true });
                        angerSignals.Find(p => p.Signalid == 5).Hasbeenused = true;
                        break;
                    case '6':
                        _event.Angersignal.Add(new AngerSignal { Signalid = 6, Signalname = "Clenching your jaws or grinding your teeth", Hasbeenused = true });
                        angerSignals.Find(p => p.Signalid == 6).Hasbeenused = true;
                        break;
                    case '7':
                        _event.Angersignal.Add(new AngerSignal { Signalid = 7, Signalname = "Clinched fists", Hasbeenused = true });
                        angerSignals.Find(p => p.Signalid == 7).Hasbeenused = true;
                        break;
                    case '8':
                        _event.Angersignal.Add(new AngerSignal { Signalid = 8, Signalname = "Sweating, especially your palms", Hasbeenused = true });
                        angerSignals.Find(p => p.Signalid == 8).Hasbeenused = true;
                        break;
                    case '9':
                        _event.Angersignal.Add(new AngerSignal { Signalid = 9, Signalname = "Feeling hot in the neck/face", Hasbeenused = true });
                        angerSignals.Find(p => p.Signalid == 9).Hasbeenused = true;
                        break;
                    case '0':
                        exit = false;
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
        public void AddNewEventSummary()
        {

        }

    }
}
