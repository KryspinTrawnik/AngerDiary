using System;
using System.Collections.Generic;
using System.Text;
using AngerDiary.Domain.Common;


namespace AngerDiary.Domain.Entity
{
    public class Raport : BaseEntity
    {
        DateTime DateOfRaport { get; set; }
            
        int EventsCount { get; set; }
        
        double AngerLevelAvarage { get; set; }

        Reducer TheMostUsedReducer { get; set; }

        Stage StrongSideStage { get; set; }

        Stage SecondStrongSideStage { get; set; }

        Stage StageToImprove { get; set; }
    }
}
