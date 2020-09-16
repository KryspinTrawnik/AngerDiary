using System;
using System.Collections.Generic;
using System.Text;

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

        public void Menage()
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
                Console.WriteLine("How angery were you in scale 0 to 10");
                string givenangerlevel = Console.ReadLine();
                checksucessful= Int32.TryParse(givenangerlevel, out angerlevel);
                _event.Angerlevel = angerlevel;
                if (angerlevel > 10 || angerlevel < 0)
                {
                    Console.WriteLine("Anger level needs to be between 0 and 10");
                }
            }
            while (!checksucessful && angerlevel > 10 && angerlevel < 0);
        }

        public void AddNewEventSignals()
        {

            
        }

        public void AddNewEventSummary()
        {
          
        }
    }
}
