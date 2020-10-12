using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace AngerDiary
{
    public class EventService
    {
        public List<Event> Events { get; set; }
        public EventService()
        {
            Events = new List<Event>();

        }


        public void Add(Event newEvent)
        {
            
            long max = 0;
            if (Events.Count < 1)
                newEvent.Id = 1;
            else
            {
                foreach (var item in Events)
                {
                    if (item.Id >= max)
                    {
                       newEvent.Id = item.Id + 1;
                        max = item.Id;
                    }
                }
            }
           
            Events.Add(newEvent);
        }

        public void EventView()
        {

        }
    }
}
