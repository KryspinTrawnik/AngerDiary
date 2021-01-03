using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace AngerDiary.App.Concrete
{
    public class StrongSideService
    {
        private StrongSideItems strongSide;
        private StageService stageService;

        public StrongSideService()
        {
            strongSide = new StrongSideItems();
            stageService = new StageService();
        }

        public StrongSideItems StrongSidesCount(EventService eventService)
        {
            
            foreach(Event @event in eventService.Items)
            {
                for (int i = 0; @event.SelfEvaluation.Count > i; i++)
                {
                   strongSide.StrongSideIdCount[@event.SelfEvaluation[i-1].Id].Item2++;
                }
            }

            strongSide.StrongSideIdCount = strongSide.StrongSideIdCount.ToList().OrderBy(x => x.Item2).ToArray();

            strongSide.StrongSideId = strongSide.StrongSideIdCount
                .ToList()
                .First().Item1;

            strongSide.SecondStrongSideId = strongSide.StrongSideIdCount
              .ToList()
              .Skip(1)
              .First().Item1;

           var idOfStagesToImprove = strongSide.StrongSideIdCount.ToList()
                .Skip(2)
                .Select(stage => stage.Item1).ToList();

            stageService.Items
                 .Clear();

            stageService.Items
                .PickFromInitialList();

            idOfStagesToImprove.ForEach(id => strongSide.StagesToImprove.Add(stageService.FindStageById(id)));

            return strongSide;
        }
    }
}
