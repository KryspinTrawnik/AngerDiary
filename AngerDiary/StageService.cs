using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngerDiary
{
    class StageService
    {
        private List<Stage> _stages;

        public StageService()
        {
            this._stages = new List<Stage>();
        }
        public StageService(List<Stage> stages)
            : this()
        {
            this._stages = stages;
        }
        public void AddNewStage(int stageId, string stageName, bool hasBeenUsed)
        {
            Stage stage = new Stage (stageId, stageName, hasBeenUsed);
            _stages.Add(stage);
        }
        public List<Stage> AddNotUsedStage()
        {
            List<Stage> result = new List<Stage>();
            foreach (var stage in _stages)
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
                if (stage.StageId == 1) ///Valuation process
                {
                    stage.StageId = 10;
                }
                if (stage.StageId == 2)
                {
                    stage.StageId = 11;
                }
                if (stage.StageId == 3)
                {
                    stage.StageId = 12;
                }
                if (stage.StageId == 4)
                {
                    stage.StageId = 9;
                }
                if (stage.StageId == 5)
                {
                    stage.StageId = 7;
                }
                if (stage.StageId == 6)
                {
                   stage.StageId = 8;
                }

            }
            Stage stageToImprve = weakStages.Find(x => x.StageId == weakStages.Max(x => x.StageId));
            return stageToImprve;
        }
    }
}
