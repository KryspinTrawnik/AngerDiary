using AngerDiary.App.Common;
using AngerDiary.Domain.Entity;
using System.Collections.Generic;

namespace AngerDiary.App.Concrete
{
    public class EventService : BaseService<Event>
    {
        public List<Event> Events { get; set; }
        public EventService()
        {
            Events = new List<Event>();

        }
        public Event AddId(Event newEvent)
        {
            newEvent.Id = Items.Count + 1;
            return newEvent;
        }
        public void AddTestEvents(List<Event> testevents)
        {
            Items.AddRange(testevents);
        }
    }
}
