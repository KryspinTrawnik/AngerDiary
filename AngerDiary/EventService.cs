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
            if (Events.Count == 0)
            {
                newEvent.Id = 1;
            }
            else
            {
                newEvent.Id = Events.Count + 1;
            }
            
            Events.Add(new Event(newEvent));
            
            
        }

        public void EventView()
        {

        }
    }
}
