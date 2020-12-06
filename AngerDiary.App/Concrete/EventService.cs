using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AngerDiary.App.Common;
using AngerDiary.Domain.Entity;

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
            newEvent.Id = Events.Count +1;
            return newEvent;
        }
        public void AddTestEvents(List<Event> testevents)
        {
            Events.AddRange(testevents);
        }
    }
}
