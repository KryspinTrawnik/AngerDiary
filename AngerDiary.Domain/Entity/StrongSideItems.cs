using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary.Domain.Entity
{
    public class StrongSideItems
    {
        public (int, int)[] StrongSideIdCount { get; set; } 

        public int SecondStrongSideId { get; set; }
        
        public int StrongSideId { get; set; }
        
        public List<Stage> StagesToImprove { get; set; }

        public StrongSideItems()
        {
            StrongSideIdCount = new (int, int)[] { (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0) };
            StagesToImprove = new List<Stage>();
        }
    }
}
