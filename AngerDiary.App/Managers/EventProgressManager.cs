using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AngerDiary.App.Managers
{
    public class EventProgressManager
    {
        private EventProgressItems EventProgressItems;

        public EventProgressManager(EventService eventService)
        {
            EventProgressItems = new EventProgressItems(eventService);
        }
        public void Menage()
        {
            AngerLevelAvarege();
            TheMostCommonReducer();
            StrongSide();
            StageToImprove();
        }
        public void AngerLevelAvarege()
        {
            EventProgressItems.AverageAngerSignalItems = EventProgressItems.AvaregeAngerLevelService
                .AvarageAngerSignal(EventProgressItems.EventService);
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            Console.WriteLine();
            Console.WriteLine($"From {EventProgressItems.EventService.Items[0].TimeOfEvent.Day}/" +
            $"{EventProgressItems.EventService.Items[0].TimeOfEvent.Month}/{EventProgressItems.EventService.Items[0].TimeOfEvent.Year} you had " +
            $"{EventProgressItems.EventService.Items.Count} events");
            Console.WriteLine($"Your average is from {EventProgressItems.AverageAngerSignalItems.TheNearestDate}");
            Console.WriteLine($"General average of anger level is {EventProgressItems.AverageAngerSignalItems.GeneralAverage} ");
            Console.WriteLine($"{EventProgressItems.AverageAngerSignalItems.IncreasedOrDeacresedText} " +
            $"{Math.Round(EventProgressItems.AverageAngerSignalItems.DifferenceBetweenAverges, 2)}+" +
            $" ({EventProgressItems.AverageAngerSignalItems.PrecentageDifferenceBetweenAverges.ToString("P1", culture)} )");
            
        }
        public void TheMostCommonReducer()
        {
            var mostUsedReducer = EventProgressItems.TheMostUsedReducer.FindMostUsedReducer(EventProgressItems.EventService);
            Console.WriteLine("The most used Reducer by you is:");
            Console.WriteLine($"{mostUsedReducer.Id}. {mostUsedReducer.Name}");
            Console.WriteLine();
        }
        public void StrongSide()
        {
            EventProgressItems.StrongSideItems = EventProgressItems.StrongSideService.StrongSidesCount(EventProgressItems.EventService);
            Console.WriteLine($"{EventProgressItems.StageService.FindStageById(EventProgressItems.StrongSideItems.StrongSideId).Name}"+
               $"{EventProgressItems.StageService.FindStageById(EventProgressItems.StrongSideItems.SecondStrongSideId).Id}") ;
            Console.WriteLine($"{EventProgressItems.StageService.FindStageById(EventProgressItems.StrongSideItems.SecondStrongSideId).Id}"+
                $"{ EventProgressItems.StageService.FindStageById(EventProgressItems.StrongSideItems.SecondStrongSideId).Name}");
        }
        public void StageToImprove()
        {
            Console.WriteLine(" You need to work out on stage:");
            Console.WriteLine(EventProgressItems.StageToImproveService.StageToImprove(EventProgressItems.StrongSideItems.StagesToImprove).Name);
        }
    }
}
