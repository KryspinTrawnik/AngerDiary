using AngerDiary.Domain.Entity;
using System;

namespace AngerDiary.App.Concrete
{
    public class ViewEvent
    {
        public void EventToView(Event eventToView)
        {

            Console.WriteLine("Time of the event is:");
            Console.WriteLine($"{eventToView.TimeOfEvent}");
            Console.WriteLine("Anger level from the event is:");
            Console.WriteLine($"{eventToView.AngerLevel}");
            Console.WriteLine("Description of the event is:");
            Console.WriteLine($"{eventToView.Description}");
            Console.WriteLine("Internal triggers from the event are:");
            Console.WriteLine($"{eventToView.InternalTriggers}");
            Console.WriteLine("External triggers from the event are:");
            Console.WriteLine($"{eventToView.ExternalTriggers}");
            Console.WriteLine("Anger signals of the event are:");
            foreach (AngerSignal angerSignal in eventToView.AngerSignals)
            {
                Console.WriteLine(angerSignal.Name);
            }
            Console.WriteLine("Reducers used in the event are:");
            foreach (Reducer reducer in eventToView.Reducers)
            {
                Console.WriteLine(reducer.Name);
            }
            Console.WriteLine("Self-instructions from the event is:");
            Console.WriteLine($"{eventToView.SelfInstruction}");
            Console.WriteLine("Consequences from the event are:");
            Console.WriteLine($"{eventToView.Consequences}");
            Console.WriteLine("On these stages you did well during the event:");
            foreach (Stage stage in eventToView.SelfEvaluation)
            {
                Console.WriteLine(stage.Name);
            }
            Console.WriteLine("These are your self-coaching thoughts:");
            Console.WriteLine($"{eventToView.SelfCoaching}");
        }
    }
}
