using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Diagnostics.Contracts;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AngerDiary
{
    public class EventService
    {
        public List<Event> Events { get; set; }
        public EventService()
        {
            Events = new List<Event>();

        }


        public void Add(Event newEvent)
        {


            newEvent.Id = Events.Count + 1;


            Events.Add(newEvent);

        }
        public void ViewYourGeneralProgressMenage()
        {
            AngerLevelAvarege();
            TheMostCommonReducer();
            StrongSide();
            int[] stagesCount = StrongSide(); 
            StageToImprove(stagesCount);
        }
        public void AngerLevelAvarege()
        {
            Console.WriteLine();
            Console.WriteLine($"From {Events[0].TimeOfEvent.Day}/{Events[0].TimeOfEvent.Month}/{Events[0].TimeOfEvent.Year} you had {Events.Count} events");
            List<int> generalAngerLevelList = new List<int>();
            List<int> monthEarlierAngerLevelList = new List<int>();
            DateTime today = DateTime.Now;
            DateTime monthEarlier = today.AddMonths(-1);
            int result;
            foreach (Event @event in Events)
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
            bool isBigger = Double.IsNegative(differenceBetweenAverges);
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
        public void TheMostCommonReducer()
        {
            int[] reducerIdCount = new int[] { 0, 0, 0, 0, 0 };
            foreach (Event @event in Events)
            {
                foreach (Reducer reducer in @event.Reducers)
                {
                    if (reducer.reducerId == 1)
                    {
                        reducerIdCount[1]++;
                    }
                    else if (reducer.reducerId == 2)
                    {
                        reducerIdCount[2]++;
                    }
                    else if (reducer.reducerId == 3)
                    {
                        reducerIdCount[3]++; ;
                    }
                    else if (reducer.reducerId == 4)
                    {
                        reducerIdCount[4]++;
                    }

                    if (@event.Id == Events.Count)
                    {
                        int maxValue = reducerIdCount.Max();
                        int mostUsedReducerId = Array.LastIndexOf(reducerIdCount, maxValue);
                        foreach (Event @event1 in Events)
                        {
                            foreach (Reducer reducer1 in event1.Reducers)
                            {
                                if (reducer1.reducerId == mostUsedReducerId && @event1.Id == Events.Count)
                                {
                                    Console.WriteLine("The most used Reducer by you is:");
                                    Console.WriteLine($"{reducer1.reducerId}. {reducer1.reducerName}");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
        }
        public int[] StrongSide()
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
            foreach (Event @event in Events)
            {
                foreach (Stage stage in @event.SelfEvaluation)
                {
                    if (stage.StageId == 1)
                    {
                        strongSideIdCount[0]++;
                    }
                    else if (stage.StageId == 2)
                    {
                        strongSideIdCount[1]++;
                    }
                    else if (stage.StageId == 3)
                    {
                        strongSideIdCount[2]++; ;
                    }
                    else if (stage.StageId == 4)
                    {
                        strongSideIdCount[3]++;
                    }
                    else if (stage.StageId == 5)
                    {
                        strongSideIdCount[4]++;
                    }
                    else if (stage.StageId == 6)
                    {
                        strongSideIdCount[5]++;
                    }

                    if (@event.Id == Events.Count && (@event.SelfEvaluation.IndexOf(stage) +1) == @event.SelfEvaluation.Count)
                    {
                         maxValue = strongSideIdCount.Max();
                         strongSideId = Array.LastIndexOf(strongSideIdCount, maxValue);
                        
                        for(int i = 0; i < strongSideIdCount.Length; i++)
                        {
                            if (i != strongSideId )
                            {
                                if (secondMaxValue < strongSideIdCount[i])
                                {
                                    secondMaxValue = strongSideIdCount[i];
                                    secondStrongSideId = i+1;
                                }
                            }
                                
                            if(i == 5)
                            {

                                foreach (Event @event1 in Events)
                                {

                                    foreach (Stage stage1 in event1.SelfEvaluation)
                                    {
                                        if (stage1.StageId == strongSideId)
                                        {
                                            twoMostCommonStages.Add(stage1);

                                        }
                                        else if (stage1.StageId == secondStrongSideId)
                                        {
                                            twoMostCommonStages.Add(stage1);
                                        }
                                        else
                                        {
                                            stagesToImprove.Add(stage1);
                                        }

                                    }
                                    if (event1.Id == Events.Count)
                                    {
                                        Console.WriteLine("You are good on these stages:");
                                        Console.WriteLine($"{twoMostCommonStages.Find(x => x.StageId == strongSideId).StageName}");
                                        Console.WriteLine($"{twoMostCommonStages.Find(x => x.StageId == secondStrongSideId).StageName}");
                                    }
                                }
                            }
                            

                        }
                        
                    }
                }
            }
            return strongSideIdCount;


        }
        public void StageToImprove(int[] stagesCount)
        {
            StageService stageService = new StageService();
            List<Stage> allStages = new List<Stage>();
            allStages.Add(new Stage { StageId = 1, StageName = "Recognizing triggers", HasBeenUsed = true });// 10
            allStages.Add(new Stage { StageId = 2, StageName = "Recognizing signals of anger", HasBeenUsed = true });//11
            allStages.Add(new Stage { StageId = 3, StageName = "Using anger reducers", HasBeenUsed = true });//12
            allStages.Add(new Stage { StageId = 4, StageName = "Self-instruction to keep yourself calm", HasBeenUsed = true });//9
            allStages.Add(new Stage { StageId = 5, StageName = "Self-rewarding for good effort", HasBeenUsed = true });//7
            allStages.Add(new Stage { StageId = 6, StageName = "Looking at the good or bad consequences", HasBeenUsed = true });//8
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
                Console.WriteLine(stageService.Valuation(weakStages).StageName);
            }
            else
            {
                Console.WriteLine("Try better on this one :");
                Console.WriteLine(allStages[Array.IndexOf(countOfStages, minValue)].StageName);
            }

        }


        public void AddTestEvents(List<Event> testevents)
        {
            Events.AddRange(testevents);
        }
    }
}
