using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngerDiary.App.Concrete
{
    public class AvaregeAngerLevelService
    {
        public AverageAngerSignalItems AverageAngerSignalItems;

        public AvaregeAngerLevelService()
        {
            AverageAngerSignalItems = new AverageAngerSignalItems();
        }
        public AverageAngerSignalItems AvarageAngerSignal(EventService eventService)
        {
            foreach(Event _event in eventService.Items)
            {
                AverageAngerSignalItems.GeneralAngerLevelList.Add(_event.AngerLevel);
                AverageAngerSignalItems.AllDates.Add(_event.TimeOfEvent);
            }
            AverageAngerSignalItems.TheNearestDate = AverageAngerSignalItems.AllDates.Max();
            AverageAngerSignalItems.MonthEarlierDate = AverageAngerSignalItems.TheNearestDate.AddMonths(-1);
            foreach (Event _event in eventService.Items)
            {
                AverageAngerSignalItems.CompareReuslt = DateTime.Compare(AverageAngerSignalItems.MonthEarlierDate, _event.TimeOfEvent);
                if(AverageAngerSignalItems.CompareReuslt <= 0)
                {
                    AverageAngerSignalItems.MonthEarlierAngerLevelList.Add(_event.AngerLevel);
                }
            }
            AverageAngerSignalItems.MonthEarlierAverage = AverageAngerSignalItems.MonthEarlierAngerLevelList.Average();
            AverageAngerSignalItems.GeneralAverage = AverageAngerSignalItems.GeneralAngerLevelList.Average();
            AverageAngerSignalItems.DifferenceBetweenAverges = AverageAngerSignalItems.GeneralAverage - 
                AverageAngerSignalItems.MonthEarlierAverage;
            if (AverageAngerSignalItems.DifferenceBetweenAverges > 0)
            {
                AverageAngerSignalItems.PrecentageDifferenceBetweenAverges =
                    (AverageAngerSignalItems.GeneralAverage / AverageAngerSignalItems.MonthEarlierAverage) - 1;
                AverageAngerSignalItems.IncreasedOrDeacresedText = "It has increased from the last month by";
            }
            else
            {
                AverageAngerSignalItems.PrecentageDifferenceBetweenAverges =
                    1 - (AverageAngerSignalItems.GeneralAverage / AverageAngerSignalItems.MonthEarlierAverage);
                AverageAngerSignalItems.IncreasedOrDeacresedText = "It has decreased from the last month by";
            }

                return AverageAngerSignalItems;
        }
    }
}
