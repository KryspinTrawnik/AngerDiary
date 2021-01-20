using System;
using System.Collections.Generic;
using System.Text;
using AngerDiary.Domain.Entity;
using AngerDiary.App.Concrete;


namespace AngerDiary.Domain.Entity
{
    public class EventProgressItems
    {
        public StageService stageService { get; set; }

        public StrongSideService strongSideService { get; set; }

        public StageToImproveService stageToImproveService { get; set; }

        public StrongSideItems strongSideItems { get; set; }

        public EventService eventService { get; set; }

        public TheMostUsedReducer theMostUsedReducer { get; set; }

        public AverageAngerSignalItems averageAngerSignalItems { get; set; }

        public AvaregeAngerLevelService avaregeAngerLevelService { get; set; }

        public EventProgressItems(EventService eventService)
        {
            stageService = new StageService();
            strongSideService = new StrongSideService();
            stageToImproveService = new StageToImproveService();
            strongSideItems = new StrongSideItems();
            theMostUsedReducer = new TheMostUsedReducer();
            avaregeAngerLevelService = new AvaregeAngerLevelService();
            averageAngerSignalItems = new AverageAngerSignalItems();
            this.eventService = eventService;
        }
    }

}
