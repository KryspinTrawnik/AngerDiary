using AngerDiary.App.Common;
using AngerDiary.Domain.Entity;
using System.Collections.Generic;

namespace AngerDiary.App.Concrete
{
    public class EventService : BaseService<Event>
    {
        
        public int AddId()
        {
            int Id = Items.Count + 1;
            return Id;
        }
        public void AddRangeOfEvents(List<Event> events)
        {
            Items.AddRange(events);
        }
    }
}
