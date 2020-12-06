using AngerDiary.App.Common;
using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AngerDiary.App.Concrete
{
    class StageService : BaseService<Stage>
    {
        public StageService()
        {
            Initialize();
        }
        public List<Stage> AddNotUsedStage()
        {
            List<Stage> result = new List<Stage>();
            foreach (var stage in Items)
            {
                if (stage.HasBeenUsed == false)
                {
                    result.Add(stage);
                }

            }
            return result;
        }

        public Stage Valuation(List<Stage> stages)
        {
            List<Stage> weakStages = stages;
            foreach(Stage stage in weakStages)
            {
                if (stage.Id == 1) ///Valuation process
                {
                    stage.Id = 10;
                }
                if (stage.Id == 2)
                {
                    stage.Id = 11;
                }
                if (stage.Id == 3)
                {
                    stage.Id = 12;
                }
                if (stage.Id == 4)
                {
                    stage.Id = 9;
                }
                if (stage.Id == 5)
                {
                    stage.Id = 7;
                }
                if (stage.Id == 6)
                {
                   stage.Id = 8;
                }

            }
            Stage stageToImprve = weakStages.Find(x => x.Id == weakStages.Max(y => y.Id));
            return stageToImprve;
        }
        private void Initialize()
        {
            AddItem(new Stage(1, "Recognizing triggers", false));
            AddItem(new Stage(2, "Recognizing signals of anger", false));
            AddItem(new Stage(3, "Using anger reducers", false));
            AddItem(new Stage(4, "Self-instruction to keep yourself calm", false));
            AddItem(new Stage(5, "Self-rewarding for good effort", false));
            AddItem(new Stage(6, "Looking at the good or bad consequences", false));

            
        }
    }
}
