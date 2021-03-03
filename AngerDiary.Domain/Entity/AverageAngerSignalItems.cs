using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary.Domain.Entity
{
    public class AverageAngerSignalItems
    {
        public List<int> GeneralAngerLevelList { get; set; }

        public List<int> MonthEarlierAngerLevelList { get; set; }

        public DateTime TheNearestDate { get; set; }

        public DateTime MonthEarlierDate { get; set; }

        public List<DateTime> AllDates { get; set; }

        public double GeneralAverage { get; set; }

        public double MonthEarlierAverage { get; set; }

        public double DifferenceBetweenAverges { get; set; }

        public double PrecentageDifferenceBetweenAverges { get; set; }

        public int CompareReuslt { get; set; }

        public string IncreasedOrDeacresedText { get; set; }

        public AverageAngerSignalItems()
        {
            GeneralAngerLevelList = new List<int>();
            MonthEarlierAngerLevelList = new List<int>();
            AllDates = new List<DateTime>();

        }
    }
}
