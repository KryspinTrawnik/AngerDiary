using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace AngerDiary.App.Concrete
{
    public class StrongSideService
    {
        private StrongSideItems StrongSide;
        

        public StrongSideService()
        {
            StrongSide = new StrongSideItems();
        }

        public StrongSideItems StrongSidesCount(EventService eventService, StageService stageService)
        {
            
            foreach(Event @event in eventService.Items)
            {
                for (int i = 1; @event.SelfEvaluation.Count > i; i++)
                {
                   StrongSide.StrongSideIdCount[@event.SelfEvaluation[i].Id - 1].Item2++;
                }
            }

            StrongSide.StrongSideIdCount = StrongSide.StrongSideIdCount.ToList().OrderBy(x => x.Item2).ToArray();

            StrongSide.StrongSideId = StrongSide.StrongSideIdCount.ToList()
                .First().Item1;

            StrongSide.SecondStrongSideId = StrongSide.StrongSideIdCount.ToList()
              .Skip(1)
              .First().Item1;

           var idOfStagesToImprove = StrongSide.StrongSideIdCount.ToList()
                .Skip(2)
                .Select(stage => stage.Item1).ToList();

            stageService.Items
                 .Clear();

            stageService.Items
                .PickFromInitialList();

            idOfStagesToImprove.ForEach(id => StrongSide.StagesToImprove.Add(stageService.FindStageById(id)));

            return StrongSide;
        }
    }
}
