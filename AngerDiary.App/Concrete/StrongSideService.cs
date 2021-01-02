using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary.App.Concrete
{
    public class StrongSideService
    {
        private StrongSideItems strongSide;

        public StrongSideService()
        {
            var strongSide = new StrongSideItems();
        }

        public StrongSideItems StrongSidesCount(EventService eventService)
        {
            foreach(Event @event in eventService.Items)
            {
                for(int i = 0; @event.SelfEvaluation.Count > i; i++)
                {
                    strongSide.StrongSideIdCount[@event.SelfEvaluation[i].Id, 0]++;
                }
            }
            return strongSide;
        }
    }
}
