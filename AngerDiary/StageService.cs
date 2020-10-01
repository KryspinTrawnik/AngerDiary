﻿using System;
using System.Collections.Generic;
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
        public StageService(List<Stage> _stages)
            : this()
        {
            this._stages = _stages;
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
                if (stage.hasBeenUsed == false)
                {
                    result.Add(stage);
                }

            }
            return result;
        }
    }
}
