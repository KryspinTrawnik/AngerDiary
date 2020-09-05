using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace AngerDiary
{
    public class EventService
    {
        public List<Event> Items { get; set; }
        public EventService()
        {
            Items = new List<Event>();

        }
        public DateTime AddNewEventDate()
        {
            string giventime;
            Event item = new Event();
            Console.WriteLine("Please, enter date and time of a new event");
            Console.WriteLine("Please, use format YYYY/MM/DD");
            giventime = Console.ReadLine();
            DateTime timeofevent;
            DateTime.TryParse(giventime, out timeofevent);
            item.Timeofevent = timeofevent;

           
            return timeofevent;
        }
        public void AddNewEventFeatures()
        {
            
            Event item = new Event();
            Console.WriteLine("Describe the event:");
            string description = Console.ReadLine();
            item.Description = description;
            
            Console.WriteLine("What were your external triggers");
            item.Externaltriggers = Console.ReadLine();
            Console.WriteLine("What were your intternal triggers");
            item.Internaltriggers = Console.ReadLine();
            
        }
    }
}
