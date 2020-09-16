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
        
        private static AngerSignalService Initialize(AngerSignalService angersignalService)
        {
            angersignalService.AddNewSignal(1, "Raised voice", false);
            angersignalService.AddNewSignal(2, "Headaches", false);
            angersignalService.AddNewSignal(3, "Stomachaches", false);
            angersignalService.AddNewSignal(4, "Increased heart rate", false);
            angersignalService.AddNewSignal(5, "Raised blood pressure", false);
            angersignalService.AddNewSignal(6, "Clenching your jaws or grinding your teeth", false);
            angersignalService.AddNewSignal(7, "Clinched fists", false);
            angersignalService.AddNewSignal(8, "Sweating, especially your palms", false);
            angersignalService.AddNewSignal(9, "Feeling hot in the neck/face", false);

            return angersignalService;
        }
    }
}
