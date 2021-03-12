using AngerDiary.Domain.Entity;
using System.Collections.Generic;

namespace AngerDiary.App.Concrete
{
    public class View7LastEvents
    {
        public List<Event> Last7Events(EventService eventService)
        {
            int start = 0;
            List<Event> eventsToView = new List<Event>();

            if (eventService.Items.Count > 7)
            {
                start = eventService.Items.Count - 7;
            }
            for (int i = start; eventService.Items.Count > i; i++)
            {
                eventsToView.Add(eventService.Items[i]);
                eventsToView[i].Id = eventsToView.Count;
            }
            return eventsToView;
        }
    }
}
