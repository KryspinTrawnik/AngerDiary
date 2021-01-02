using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary.Domain.Entity
{
    public class StrongSideItems
    {
        public int[,] StrongSideIdCount { get; set; } 

        public int SecondStrongSideId { get; set; }
        
        public int MaxValue { get; set; }
        
        public int StrongSideId { get; set; }

        public int SecondMaxValue { get; set; }

        List<Stage> TwoMostCommonStages { get; set; }

        List<Stage> StagesToImprove { get; set; }

        public StrongSideItems()
        {
            StrongSideIdCount = new int[,] { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 } };
            TwoMostCommonStages = new List<Stage>(); 
            StagesToImprove = new List<Stage>();
        }
    }
}
