using System;
using System.Collections.Generic;
using System.Text;
using AngerDiary.Domain.Entity;
using AngerDiary.App.Concrete;
using AngerDiary.App.Common;

namespace AngerDiary.App.Concrete
{
    public class RaportService : BaseService<Raport>
    {
        private Raport Raport;
        private EventProgressItems EventProgressItems;
        public RaportService()
        {
            Raport = new Raport();
        }

        public Raport CreateRaport(EventService eventService)
        {
            EventProgressItems = new EventProgressItems(eventService);
            EventProgressItems.StrongSideItems = EventProgressItems.StrongSideService.StrongSidesCount(EventProgressItems.EventService);
            
            Raport.Id = Items.Count + 1;
            
            Raport.Date = DateTime.Today;
            
            Raport.EventsCount = EventProgressItems.EventService.Items.Count;
            
            Raport.AngerLevelAvarage = EventProgressItems.AverageAngerSignalItems.GeneralAverage;
            
            Raport.StrongSideStage = EventProgressItems.StageService.FindStageById(EventProgressItems.StrongSideItems.StrongSideId);
            
            Raport.SecondStrongSideStage = EventProgressItems.StageService.FindStageById(EventProgressItems.StrongSideItems.SecondStrongSideId);
            
            Raport.StageToImprove = EventProgressItems.StageToImproveService.
            StageToImprove(EventProgressItems.StrongSideItems.StagesToImprove);

            return Raport;
        }
    }
}
