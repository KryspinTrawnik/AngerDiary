using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Diagnostics.Contracts;
using System.Collections.Immutable;

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
            if (Events.Count == 0)
            {
                newEvent.Id = 1;
            }
            else
            {
                newEvent.Id = Events.Count + 1;
            }
            
            Events.Add(new Event(newEvent));
            
        }

        public void ViewLast7Events()
        {
            
            int id = 0;
            bool exit = false;
            int operation = 0;
            int testoperation = 0;
            bool checksucessful;
            Helpers helpers = new Helpers();
            int start = 0;
            if (Events.Count > 7)
            {
                start = Events.Count - 7;
            }
            do
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose which event would you like to see");
                    Console.WriteLine("When you finish press 0");
                    for (int i = start; Events.Count > i; i++)
                    {
                        Console.WriteLine($"Date: {Events[i].Timeofevent} Anger level was: {Events[i].Angerlevel}");
                    }
                    string givenoperation = Console.ReadLine();
                    checksucessful = Int32.TryParse(givenoperation, out testoperation);
                    if (testoperation > 7 || testoperation < 0 || checksucessful == false)
                    {
                        Console.WriteLine("Chosen id needs to be a number between 0 and 7");
                    }
                    else if(testoperation == 0)
                    {
                        exit = true;
                    }
                    else
                    {
                        operation = testoperation;
                        helpers.EventToView(Events.Find(x => x.Id == operation));
                    }
                } while (!checksucessful);
               
            } while (!(exit == true));
        }
    }
}
