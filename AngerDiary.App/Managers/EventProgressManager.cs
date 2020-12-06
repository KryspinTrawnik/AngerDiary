using AngerDiary.App.Concrete;
using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AngerDiary.App.Managers
{
    public class EventProgressManager
    {
        public void Menage(EventService eventService)
        {
            AngerLevelAvarege(eventService);
            TheMostCommonReducer(eventService);
            StrongSide(eventService);
            int[] stagesCount = StrongSide(eventService);
            StageToImprove(stagesCount, eventService);
        }
        public void AngerLevelAvarege(EventService eventService)
        {
            Console.WriteLine();
            Console.WriteLine($"From {eventService.Events[0].TimeOfEvent.Day}/{eventService.Events[0].TimeOfEvent.Month}/{eventService.Events[0].TimeOfEvent.Year} you had {eventService.Events.Count} events");
            List<int> generalAngerLevelList = new List<int>();
            List<int> monthEarlierAngerLevelList = new List<int>();
            DateTime today = DateTime.Now;
            DateTime monthEarlier = today.AddMonths(-1);
            int result;
            foreach (Event @event in eventService.Events)
            {
                generalAngerLevelList.Add(@event.AngerLevel);
                result = DateTime.Compare(monthEarlier, @event.TimeOfEvent);
                if (result <= 0)
                {
                    monthEarlierAngerLevelList.Add(@event.AngerLevel);
                }
            }
            double generalAverage = generalAngerLevelList.Average();
            double monthEarlierAverage = monthEarlierAngerLevelList.Average();
            double differenceBetweenAverges = generalAverage - monthEarlierAverage;
            bool isBigger = Double.IsNegativeInfinity(differenceBetweenAverges);
            double theDifferenceInPrecentage;
            if (isBigger == false)
            {
                theDifferenceInPrecentage = ((generalAverage - monthEarlierAverage) - 1) * 100;
                Console.WriteLine($"General average of anger level is {generalAverage} ");
                Console.WriteLine($"It has increased from the last month by {differenceBetweenAverges} ( {theDifferenceInPrecentage.ToString("P1", CultureInfo.InvariantCulture)} )");
            }
            else
            {
                theDifferenceInPrecentage = (1 - (generalAverage - monthEarlierAverage)) * 100;
                Console.WriteLine($"General average of anger level is {generalAverage}");
                Console.WriteLine($"It has decreased from the last month by {differenceBetweenAverges} ( {theDifferenceInPrecentage.ToString("P1", CultureInfo.InvariantCulture)} )");
            }
        }
        public void TheMostCommonReducer(EventService eventService)
        {
            int[] reducerIdCount = new int[] { 0, 0, 0, 0, 0 };
            foreach (Event @event in eventService.Events)
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

                    if (@event.Id == eventService.Events.Count)
                    {
                        int maxValue = reducerIdCount.Max();
                        int mostUsedReducerId = Array.LastIndexOf(reducerIdCount, maxValue);
                        foreach (Event @event1 in eventService.Events)
                        {
                            foreach (Reducer reducer1 in event1.Reducers)
                            {
                                if (reducer1.Id == mostUsedReducerId && @event1.Id == eventService.Events.Count)
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
        public int[] StrongSide(EventService eventService)
        {
            //(1, "Recognizing triggers", false); 6pkt
            //(2, "Recognizing signals of anger", false); 8pkt
            //(3, "Using anger reducers", false); 10pkt
            //(4, "Self-instruction to keep yourself calm", false); 4pkt
            //(5, "Self-rewarding for good effort", false);  2 pkt
            //(6, "Looking at the good or bad consequences", false); 1pkt

            int[] strongSideIdCount = new int[] { 0, 0, 0, 0, 0, 0 };
            int secondStrongSideId = 0;
            int maxValue = 0;
            int strongSideId = 0;
            int secondMaxValue = 0;
            List<Stage> twoMostCommonStages = new List<Stage>();
            List<Stage> stagesToImprove = new List<Stage>();
            foreach (Event @event in eventService.Events)
            {
                foreach (Stage stage in @event.SelfEvaluation)
                {
                    if (stage.Id == 1)
                    {
                        strongSideIdCount[0]++;
                    }
                    else if (stage.Id == 2)
                    {
                        strongSideIdCount[1]++;
                    }
                    else if (stage.Id == 3)
                    {
                        strongSideIdCount[2]++; ;
                    }
                    else if (stage.Id == 4)
                    {
                        strongSideIdCount[3]++;
                    }
                    else if (stage.Id == 5)
                    {
                        strongSideIdCount[4]++;
                    }
                    else if (stage.Id == 6)
                    {
                        strongSideIdCount[5]++;
                    }

                    if (@event.Id == eventService.Events.Count && (@event.SelfEvaluation.IndexOf(stage) + 1) == @event.SelfEvaluation.Count)
                    {
                        maxValue = strongSideIdCount.Max();
                        strongSideId = Array.LastIndexOf(strongSideIdCount, maxValue);

                        for (int i = 0; i < strongSideIdCount.Length; i++)
                        {
                            if (i != strongSideId)
                            {
                                if (secondMaxValue < strongSideIdCount[i])
                                {
                                    secondMaxValue = strongSideIdCount[i];
                                    secondStrongSideId = i + 1;
                                }
                            }

                            if (i == 5)
                            {

                                foreach (Event @event1 in eventService.Events)
                                {

                                    foreach (Stage stage1 in event1.SelfEvaluation)
                                    {
                                        if (stage1.Id == strongSideId)
                                        {
                                            twoMostCommonStages.Add(stage1);

                                        }
                                        else if (stage1.Id == secondStrongSideId)
                                        {
                                            twoMostCommonStages.Add(stage1);
                                        }
                                        else
                                        {
                                            stagesToImprove.Add(stage1);
                                        }

                                    }
                                    if (event1.Id == eventService.Events.Count)
                                    {
                                        Console.WriteLine("You are good on these stages:");
                                        Console.WriteLine($"{twoMostCommonStages.Find(x => x.Id == strongSideId).Name}");
                                        Console.WriteLine($"{twoMostCommonStages.Find(x => x.Id == secondStrongSideId).Name}");
                                    }
                                }
                            }


                        }

                    }
                }
            }
            return strongSideIdCount;


        }
        public void StageToImprove(int[] stagesCount, EventService eventService)
        {
            StageService stageService = new StageService();
            List<Stage> allStages = new List<Stage>();
            allStages.Add(new Stage { Id = 1, Name = "Recognizing triggers", HasBeenUsed = true });// 10
            allStages.Add(new Stage { Id = 2, Name = "Recognizing signals of anger", HasBeenUsed = true });//11
            allStages.Add(new Stage { Id = 3, Name = "Using anger reducers", HasBeenUsed = true });//12
            allStages.Add(new Stage { Id = 4, Name = "Self-instruction to keep yourself calm", HasBeenUsed = true });//9
            allStages.Add(new Stage { Id = 5, Name = "Self-rewarding for good effort", HasBeenUsed = true });//7
            allStages.Add(new Stage { Id = 6, Name = "Looking at the good or bad consequences", HasBeenUsed = true });//8
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
