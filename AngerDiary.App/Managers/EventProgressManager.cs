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
        private StageService stageService;

        public void Menage(EventService eventService)
        {
            AngerLevelAvarege(eventService);
            TheMostCommonReducer(eventService);
            StrongSide(eventService);
            int[] stagesCount = StrongSide(eventService);
            StageToImprove(stagesCount);
        }
        public void AngerLevelAvarege(EventService eventService)
        {
            Console.WriteLine();
            Console.WriteLine($"From {eventService.Items[0].TimeOfEvent.Day}/{eventService.Items[0].TimeOfEvent.Month}/{eventService.Items[0].TimeOfEvent.Year} you had {eventService.Items.Count} events");
            List<int> generalAngerLevelList = new List<int>();
            List<int> monthEarlierAngerLevelList = new List<int>();
            DateTime today = DateTime.Now;
            DateTime monthEarlier = today.AddMonths(-1);
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            List<DateTime> alldates = new List<DateTime>();
            int result;
            foreach (Event @event in eventService.Items)
            {
                generalAngerLevelList.Add(@event.AngerLevel);
                result = DateTime.Compare(monthEarlier, @event.TimeOfEvent);
                if (result <= 0)
                {
                    monthEarlierAngerLevelList.Add(@event.AngerLevel);
                }
                alldates.Add(@event.TimeOfEvent);
            }
            double generalAverage = generalAngerLevelList.Average();
            if (monthEarlierAngerLevelList.Count > 0)
            {
                double monthEarlierAverage = monthEarlierAngerLevelList.Average();

                double differenceBetweenAverges = generalAverage - monthEarlierAverage;
                bool isBigger = Double.IsNegativeInfinity(differenceBetweenAverges);
                double theDifferenceInPrecentage;
                if (isBigger == false)
                {
                    theDifferenceInPrecentage = ((generalAverage - monthEarlierAverage) - 1);
                    Console.WriteLine($"General average of anger level is {generalAverage} ");
                    Console.WriteLine($"It has increased from the last month by {Math.Round(differenceBetweenAverges, 2)} ( {theDifferenceInPrecentage.ToString("P1", culture)} )");
                }
                else
                {
                    theDifferenceInPrecentage = (1 - (generalAverage - monthEarlierAverage));
                    Console.WriteLine($"General average of anger level is {generalAverage}");
                    Console.WriteLine($"It has decreased from the last month by {Math.Round(differenceBetweenAverges, 2)} ( {theDifferenceInPrecentage.ToString("P1", culture)} )");
                }
            }
            else
            {
                DateTime theNearstDate = alldates.Max();
                monthEarlier = theNearstDate.AddMonths(-1);
                foreach (Event @event in eventService.Items)
                {
                    generalAngerLevelList.Add(@event.AngerLevel);
                    result = DateTime.Compare(monthEarlier, @event.TimeOfEvent);
                    if (result <= 0)
                    {
                        monthEarlierAngerLevelList.Add(@event.AngerLevel);
                    }

                }
                double monthEarlierAverage = monthEarlierAngerLevelList.Average();

                double differenceBetweenAverges = generalAverage - monthEarlierAverage;

                double theDifferenceInPrecentage;
                if (differenceBetweenAverges > 0)
                {
                    theDifferenceInPrecentage = ((generalAverage / monthEarlierAverage) - 1);
                    Console.WriteLine($"Your average is from {theNearstDate}");
                    Console.WriteLine($"General average of anger level is {generalAverage} ");
                    Console.WriteLine($"It has increased from the last month by {Math.Round(differenceBetweenAverges, 2)} ({theDifferenceInPrecentage.ToString("P1", culture)} )");
                }
                else
                {
                    Console.WriteLine($"Your average is from {theNearstDate}");
                    theDifferenceInPrecentage = (1 - (generalAverage / monthEarlierAverage));
                    Console.WriteLine($"General average of anger level is {generalAverage}");
                    Console.WriteLine($"It has decreased from the last month by {Math.Round(differenceBetweenAverges, 2)} ( {theDifferenceInPrecentage.ToString("P1", culture)} )");
                }
            }
        }
        public void TheMostCommonReducer(EventService eventService)
        {
            int[] reducerIdCount = new int[] { 0, 0, 0, 0, 0 };
            foreach (Event @event in eventService.Items)
            {
                foreach (Reducer reducer in @event.Reducers)
                {
                    if (reducer.Id == 1)
                    {
                        reducerIdCount[1]++;
                    }
                    else if (reducer.Id == 2)
                    {
                        reducerIdCount[2]++;
                    }
                    else if (reducer.Id == 3)
                    {
                        reducerIdCount[3]++; ;
                    }
                    else if (reducer.Id == 4)
                    {
                        reducerIdCount[4]++;
                    }

                    if (@event.Id == eventService.Items.Count)
                    {
                        int maxValue = reducerIdCount.Max();
                        int mostUsedReducerId = Array.LastIndexOf(reducerIdCount, maxValue);
                        foreach (Event @event1 in eventService.Items)
                        {
                            foreach (Reducer reducer1 in event1.Reducers)
                            {
                                if (reducer1.Id == mostUsedReducerId && @event1.Id == eventService.Items.Count)
                                {
                                    Console.WriteLine("The most used Reducer by you is:");
                                    Console.WriteLine($"{reducer1.Id}. {reducer1.Name}");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
        }
        public int[] StrongSide(EventService eventService, StageService stageService)
        {
            var strongSideService = new StrongSideService();
            StrongSideItems strongSide = strongSideService.StrongSidesCount(eventService);
            Console.WriteLine($"The{stageService.FindStageById(strongSide.StrongSideId).Name}");
            Console.WriteLine($"The{stageService.FindStageById(strongSide.SecondStrongSideId).Name}");
            return strongSide.StagesToImprove.ToArray();


        }
        public void StageToImprove(int[] stagesCount)
        {
            
            List<Stage> allStages = new List<Stage>
            {
                new Stage { Id = 1, Name = "Recognizing triggers", HasBeenUsed = true },// 10
                new Stage { Id = 2, Name = "Recognizing signals of anger", HasBeenUsed = true },//11
                new Stage { Id = 3, Name = "Using anger reducers", HasBeenUsed = true },//12
                new Stage { Id = 4, Name = "Self-instruction to keep yourself calm", HasBeenUsed = true },//9
                new Stage { Id = 5, Name = "Self-rewarding for good effort", HasBeenUsed = true },//7
                new Stage { Id = 6, Name = "Looking at the good or bad consequences", HasBeenUsed = true }//8
            };
            List<Stage> weakStages = new List<Stage>();
            int[] countOfStages = stagesCount;
            int minValue = countOfStages.Min();
            if (Array.FindAll(countOfStages, x => x == minValue).Length > 1)
            {
                for (int i = 0; i < countOfStages.Length; i++)
                {
                    if (countOfStages[i] == 0)
                    {
                        weakStages.Add(allStages[i]);
                    }
                }

                Console.WriteLine("Try better on this one :");
                Console.WriteLine(stageService.Valuation(weakStages).Name);
            }
            else
            {
                Console.WriteLine("Try better on this one :");
                Console.WriteLine(allStages[Array.IndexOf(countOfStages, minValue)].Name);
            }

        }



    }

}
