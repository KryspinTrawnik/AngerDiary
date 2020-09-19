using System;

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
            Console.WriteLine("Choose from below which of signals did you experience");
            var angerSignals = angersignalService.AddNotUsedSignal(false);
            for(int i = 0; angerSignals.Count < i; i++)
            {
                Console.WriteLine(value: $"{angerSignals[i].Signalid}. {angerSignals[i].Signalname}.");
            }
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
