using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace AngerDiary
{
    public class EventService
    {
        public List<Event> Items { get; set; }
        public EventService()
        {
            Items = new List<Event>();

        }
        public DateTime AddNewEventDate()
        {
            string giventime;
            Event item = new Event();
            Console.WriteLine("Please, enter date and time of a new event");
            Console.WriteLine("Please, use format YYYY/MM/DD HH:MM  (Time needs to be in 24Hrs format)");
            giventime = Console.ReadLine();
            DateTime timeofevent;
            DateTime.TryParse(giventime, out timeofevent);
            item.Timeofevent = timeofevent;

           
            return timeofevent;
        }
        public void AddNewEventFeatures()
        {
            
            Event item = new Event();
            Console.WriteLine("Describe the event:");
            string description = Console.ReadLine();
            item.Description = description;
            
            Console.WriteLine("What were your external triggers");
            item.Externaltriggers = Console.ReadLine();
            Console.WriteLine("What were your intternal triggers");
            item.Internaltriggers = Console.ReadLine();
            Console.WriteLine("What signals of anger can you recoqnize");
            
            
        }
        private static AngerSignalService Initialize(AngerSignalService angersignalService)
        {
            angersignalService.AddNewSignal(1, "Raised voice");
            angersignalService.AddNewSignal(2, "Headaches");
            angersignalService.AddNewSignal(3, "Stomachaches");
            angersignalService.AddNewSignal(4, "Increased heart rate");
            angersignalService.AddNewSignal(5, "Raised blood pressure");
            angersignalService.AddNewSignal(6, "Clenching your jaws or grinding your teeth");
            angersignalService.AddNewSignal(7, "Clinched fists");
            angersignalService.AddNewSignal(8, "Sweating, especially your palms");
            angersignalService.AddNewSignal(9, "Feeling hot in the neck/face");

            return angersignalService;
        }
    }
}
