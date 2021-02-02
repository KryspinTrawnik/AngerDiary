using AngerDiary.App.Common;
using AngerDiary.Domain.Entity;
using System.Collections.Generic;
using System.Linq;


namespace AngerDiary.App.Concrete
{
    public class StageService : BaseService<Stage>
    {
        public StageService()
        {
            Initialize();
        }
        public List<Stage> GetNotUsedStage()
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
            Stage stageToImprve = stages.Find(x => x.Value == stages.Max(y => y.Value));
            return stageToImprve;
        }
        public Stage FindStageById(int id)=> new List<Stage>()
            .PickFromInitialList()
            .Find(stage => stage.Id == id);
        
        private void Initialize()
        {
            AddItem(new Stage(1, "Recognizing triggers", false, 10));
            AddItem(new Stage(2, "Recognizing signals of anger", false, 11));
            AddItem(new Stage(3, "Using anger reducers", false, 12));
            AddItem(new Stage(4, "Self-instruction to keep yourself calm", false, 9));
            AddItem(new Stage(5, "Self-rewarding for good effort", false, 7));
            AddItem(new Stage(6, "Looking at the good or bad consequences", false, 8));


        }
    }
}
