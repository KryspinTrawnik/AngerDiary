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
            EventProgressItems.averageAngerSignalItems = EventProgressItems.avaregeAngerLevelService
                .AvarageAngerSignal(EventProgressItems.eventService);
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            Console.WriteLine();
            Console.WriteLine($"From {EventProgressItems.eventService.Items[0].TimeOfEvent.Day}/" +
            $"{EventProgressItems.eventService.Items[0].TimeOfEvent.Month}/{EventProgressItems.eventService.Items[0].TimeOfEvent.Year} you had " +
            $"{EventProgressItems.eventService.Items.Count} events");
            Console.WriteLine($"Your average is from {EventProgressItems.averageAngerSignalItems.TheNearestDate}");
            Console.WriteLine($"General average of anger level is {EventProgressItems.averageAngerSignalItems.GeneralAverage} ");
            Console.WriteLine($"{EventProgressItems.averageAngerSignalItems.IncreasedOrDeacresedText} " +
            $"{Math.Round(EventProgressItems.averageAngerSignalItems.DifferenceBetweenAverges, 2)}+" +
            $" ({EventProgressItems.averageAngerSignalItems.PrecentageDifferenceBetweenAverges.ToString("P1", culture)} )");
            
        }
        public void TheMostCommonReducer()
        {
            var mostUsedReducer = EventProgressItems.theMostUsedReducer.FindMostUsedReducer(EventProgressItems.eventService);
            Console.WriteLine("The most used Reducer by you is:");
            Console.WriteLine($"{mostUsedReducer.Id}. {mostUsedReducer.Name}");
            Console.WriteLine();
        }
        public void StrongSide()
        {
            EventProgressItems.strongSideItems = EventProgressItems.strongSideService.StrongSidesCount(EventProgressItems.eventService, EventProgressItems.stageService);
            Console.WriteLine($"The{EventProgressItems.stageService.FindStageById(EventProgressItems.strongSideItems.StrongSideId).Name}");
            Console.WriteLine($"The{EventProgressItems.stageService.FindStageById(EventProgressItems.strongSideItems.SecondStrongSideId).Name}");
        }
        public void StageToImprove()
        {
            Console.WriteLine(" You need to work out on stage:");
            Console.WriteLine(EventProgressItems.stageToImproveService.StageToImprove(EventProgressItems.strongSideItems.StagesToImprove).Name);
        }
    }
}
