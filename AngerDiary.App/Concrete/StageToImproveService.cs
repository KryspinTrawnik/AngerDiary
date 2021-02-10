using AngerDiary.Domain.Entity;

using System.Collections.Generic;


namespace AngerDiary.App.Concrete
{
    public class StageToImproveService
    {
        private List<Stage> StagesToImprove;
        private StageService StageService;
        public StageToImproveService()
        {
            StagesToImprove = new List<Stage>();
            StageService = new StageService();
        }

        public Stage StageToImprove(List<Stage> stagesToImprove)
        {
            StagesToImprove = stagesToImprove;
            Stage stageToImprove = StageService.GetMostValueStage(StagesToImprove);

                return stageToImprove;
        }
    }
}
