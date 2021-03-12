using AngerDiary.Domain.Entity;
using System.Linq;


namespace AngerDiary.App.Concrete
{
    public class StrongSideService
    {
        private StrongSideItems StrongSide;
        private StageService StageService;

        public StrongSideService()
        {
            StrongSide = new StrongSideItems();
            StageService = new StageService();
        }

        public StrongSideItems StrongSidesCount(EventService eventService)
        {
            
            foreach(Event @event in eventService.Items)
            {
                for (int i = 0; @event.SelfEvaluation.Count > i; i++)
                {
                   StrongSide.StrongSideIdCount[@event.SelfEvaluation[i].Id - 1].Item2++;
                }
            }

            StrongSide.StrongSideIdCount = StrongSide.StrongSideIdCount.ToList().OrderByDescending(x => x.Item2).ToArray();

            StrongSide.StrongSideId = StrongSide.StrongSideIdCount.ToList()
                .First().Item1;

            StrongSide.SecondStrongSideId = StrongSide.StrongSideIdCount.ToList()
              .Skip(1)
              .First().Item1;

           var idOfStagesToImprove = StrongSide.StrongSideIdCount.ToList()
                .Skip(2)
                .Select(stage => stage.Item1).ToList();

            StageService.Items
                 .Clear();

            StageService.Items
                .PickFromInitialList();

            idOfStagesToImprove.ForEach(id => StrongSide.StagesToImprove.Add(StageService.FindStageById(id)));

            return StrongSide;
        }
    }
}
