using System;
using System.Collections.Generic;
using System.Text;
using AngerDiary.Domain.Common;


namespace AngerDiary.Domain.Entity
{
    public class Raport : BaseEntity
    {
        public DateTime Date { get; set; }

        public int EventsCount { get; set; }

        public double AngerLevelAvarage { get; set; }

        public Reducer TheMostUsedReducer { get; set; }

        public Stage StrongSideStage { get; set; }

        public Stage SecondStrongSideStage { get; set; }

        public Stage StageToImprove { get; set; }

        public Raport()
        {

        }
    }

}
