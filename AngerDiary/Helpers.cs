using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    class Helpers
    {
       public void EventToView(Event eventToView)
       {
    //    public string Selfcoaching { get; set; }
        Event @event = new Event(eventToView);
            Console.WriteLine("Time of the event is:");
            Console.WriteLine($"{@event.Timeofevent}");
            Console.WriteLine("Anger level from the event is:");
            Console.WriteLine($"{@event.Angerlevel}");
            Console.WriteLine("Description of the event is:");
            Console.WriteLine($"{@event.Description}");
            Console.WriteLine("Internal triggers from the event are:");
            Console.WriteLine($"{@event.Internaltriggers}");
            Console.WriteLine("External triggers from the event are:");
            Console.WriteLine($"{@event.Externaltriggers}");
            Console.WriteLine("Anger signals of the event are:");
            foreach( AngerSignal angerSignal in @event.Angersignals )
            {
                Console.WriteLine(angerSignal);
            }
            Console.WriteLine("Reducers used in the event are:");
            foreach (Reducer reducer in @event.Reducers)
            {
                Console.WriteLine(reducer);
            }
            Console.WriteLine("Self-instructions from the event is:");
            Console.WriteLine($"{@event.Selfinstruction}");
            Console.WriteLine("Self-instructions from the event is:");
            Console.WriteLine($"{@event.Selfinstruction}");
            Console.WriteLine("Self-evaluation from the event is:");
            Console.WriteLine($"{@event.Selfevaluation}");
            Console.WriteLine("Consequences from the event are:");
            Console.WriteLine($"{@event.Consequences}");
            Console.WriteLine("On these stages you did well during the event:");
            foreach (Stage stage in @event.Selfevaluation)
            {
                Console.WriteLine(stage);
            }
            Console.WriteLine("These are your self-coaching thoughts:");
            Console.WriteLine($"{@event.Selfcoaching}");
        }
    }
    
}
