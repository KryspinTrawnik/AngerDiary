
using AngerDiary.Domain.Entity;


namespace AngerDiary.App.Concrete
{
    public class EventProgressItems
    {
        public StageService StageService { get; set; }

        public StrongSideService StrongSideService { get; set; }

        public StageToImproveService StageToImproveService { get; set; }

        public StrongSideItems StrongSideItems { get; set; }

        public EventService EventService { get; set; }

        public TheMostUsedReducer TheMostUsedReducer { get; set; }

        public AverageAngerSignalItems AverageAngerSignalItems { get; set; }

        public AvaregeAngerLevelService AvaregeAngerLevelService { get; set; }

        public EventProgressItems(EventService eventService)
        {
            StageService = new StageService();
            StrongSideService = new StrongSideService();
            StageToImproveService = new StageToImproveService();
            StrongSideItems = new StrongSideItems();
            TheMostUsedReducer = new TheMostUsedReducer();
            AvaregeAngerLevelService = new AvaregeAngerLevelService();
            AverageAngerSignalItems = new AverageAngerSignalItems();
            EventService = eventService;
        }
    }

}
