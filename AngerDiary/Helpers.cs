using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    class Helpers
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
            foreach( AngerSignal angerSignal in eventToView.AngerSignals )
            {
                Console.WriteLine(angerSignal.Signalname);
            }
            Console.WriteLine("Reducers used in the event are:");
            foreach (Reducer reducer in eventToView.Reducers)
            {
                Console.WriteLine(reducer.reducerName);
            }
            Console.WriteLine("Self-instructions from the event is:");
            Console.WriteLine($"{eventToView.SelfInstruction}");
            Console.WriteLine("Consequences from the event are:");
            Console.WriteLine($"{eventToView.Consequences}");
            Console.WriteLine("On these stages you did well during the event:");
            foreach (Stage stage in eventToView.SelfEvaluation)
            {
                Console.WriteLine(stage.StageName);
            }
            Console.WriteLine("These are your self-coaching thoughts:");
            Console.WriteLine($"{eventToView.SelfCoaching}");
        }
        public List<Event> TestEvents()//Creating events for test
        {
            //allStages.Add(new Stage { StageId = 1, StageName = "Recognizing triggers", HasBeenUsed = true });// 10
            //allStages.Add(new Stage { StageId = 2, StageName = "Recognizing signals of anger", HasBeenUsed = true });//11
            //allStages.Add(new Stage { StageId = 3, StageName = "Using anger reducers", HasBeenUsed = true });//12
            //allStages.Add(new Stage { StageId = 4, StageName = "Self-instruction to keep yourself calm", HasBeenUsed = true });//9
            //allStages.Add(new Stage { StageId = 5, StageName = "Self-rewarding for good effort", HasBeenUsed = true });//7
            //allStages.Add(new Stage { StageId = 6, StageName = "Looking at the good or bad consequences", HasBeenUsed = true });//8

            List<Event> testEvents = new List<Event>();
            Event a = new Event();
            AngerSignal anger = new AngerSignal(1, "Raised voice", true);
            Reducer reducer = new Reducer(1, "Counting backward", true);
            Stage stage = new Stage(1, "Recognizing triggers", true);
            Stage stagea = new Stage(4, "Self-instruction to keep yourself calm", true);
            Stage stageab = new Stage(5, "Self-rewarding for good effort", true);
            a.Id = 1;
            a.TimeOfEvent = new DateTime(2020, 10, 30, 8, 0, 0);
            a.Description = "blabla";
            a.AngerLevel = 4;
            a.InternalTriggers = "blabla";
            a.ExternalTriggers = "blabla";
            a.AngerSignals = new List<AngerSignal>();
            a.AngerSignals.Add(anger);
            a.Reducers = new List<Reducer>();
            a.Reducers.Add(reducer);
            a.SelfInstruction = "blablba";
            a.Consequences = "blblab";
            a.SelfEvaluation = new List<Stage>();
            a.SelfEvaluation.Add(stage);
            a.SelfEvaluation.Add(stagea);
            a.SelfEvaluation.Add(stageab);
            a.SelfCoaching = "blablab";
            testEvents.Add(a);

            Event b = new Event();
            AngerSignal angerb = new AngerSignal(2, "Headaches", true);
            Reducer reducerb = new Reducer(2, "Deep breathing", true);
            Stage stageb = new Stage(1, "Recognizing triggers", true);
            Stage stageba = new Stage(1, "Recognizing triggers", true);
            b.Id = 2;
            b.TimeOfEvent = new DateTime(2020, 11, 3, 11, 0, 0);
            b.Description = "blabla";
            b.AngerLevel = 5;
            b.InternalTriggers = "blabla";
            b.ExternalTriggers = "blabla";
            b.AngerSignals = new List<AngerSignal>();
            b.AngerSignals.Add(angerb);
            b.Reducers = new List<Reducer>();
            b.Reducers.Add(reducerb);
            b.SelfInstruction = "blablba";
            b.Consequences = "blblab";
            b.SelfEvaluation = new List<Stage>();
            b.SelfEvaluation.Add(stageb);
            b.SelfCoaching = "blablab";
            testEvents.Add(b);


            Event c = new Event();
            AngerSignal angerc = new AngerSignal(2, "Headaches", true);
            Reducer reducerc = new Reducer(1, "Counting backward", true);
            Stage stagec = new Stage(2, "Recognizing signals of anger", true);
            Stage stageca = new Stage(3, "Using anger reducers", true);
            c.Id = 3;
            c.TimeOfEvent = new DateTime(2020, 10, 1, 15, 0, 0);
            c.Description = "blabla";
            c.AngerLevel = 8;
            c.InternalTriggers = "blabla";
            c.ExternalTriggers = "blabla";
            c.AngerSignals = new List<AngerSignal>();
            c.AngerSignals.Add(angerc);
            c.Reducers = new List<Reducer>();
            c.Reducers.Add(reducerc);
            c.SelfInstruction = "blablba";
            c.Consequences = "blblab";
            c.SelfEvaluation = new List<Stage>();
            c.SelfEvaluation.Add(stagec);
            c.SelfEvaluation.Add(stageca);
            c.SelfCoaching = "blablab";
            testEvents.Add(c);

            Event d = new Event();
            AngerSignal angerd = new AngerSignal(2, "Headaches", true);
            Reducer reducerd = new Reducer(2, "Deep breathing", true);
            Stage staged = new Stage(2, "Recognizing signals of anger", true);
            Stage stageda = new Stage(3, "Using anger reducers" , true);
            d.Id = 4;
            d.TimeOfEvent = new DateTime(2020, 10, 3, 11, 0, 0);
            d.Description = "blabla";
            d.AngerLevel = 8;
            d.InternalTriggers = "blabla";
            d.ExternalTriggers = "blabla";
            d.AngerSignals = new List<AngerSignal>();
            d.AngerSignals.Add(angerc);
            d.Reducers = new List<Reducer>();
            d.Reducers.Add(reducerc);
            d.SelfInstruction = "blablba";
            d.Consequences = "blblab";
            d.SelfEvaluation = new List<Stage>();
            d.SelfEvaluation.Add(staged);
            d.SelfEvaluation.Add(stageda);
            d.SelfCoaching = "blablab";
            testEvents.Add(d);
            
            
            return testEvents;

        }
        
    }
    
}
