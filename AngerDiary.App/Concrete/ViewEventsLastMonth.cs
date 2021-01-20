using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngerDiary.App.Concrete
{
    public class ViewEventsLastMonth
    {
        public List<Event> ViewLastMonth(EventService eventService)
        {
            List<DateTime> AllDates = new List<DateTime>();
            List<Event> eventsToView = new List<Event>();
            foreach(Event @event in eventService.Items)
            {
                AllDates.Add(@event.TimeOfEvent);
            }
            DateTime theNearestdate = AllDates.Max();
            DateTime monthEarlier = theNearestdate.AddMonths(-1);
            int result;
            
            for (int i = 0; eventService.Items.Count > i; i++)
            {
                result = DateTime.Compare(monthEarlier, eventService.Items[i].TimeOfEvent);
                if (result <= 0)
                {
                    eventsToView.Add(eventService.Items[i]);
                    eventsToView[(eventsToView.Count - 1)].Id = eventsToView.Count;

                }
            }
            return eventsToView;
        }
    }
}
