using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngryDiary.Tests
{
    public class EventsForTest
    {
        public List<Event> TestEvents()
        {

            List<Event> testEvents = new List<Event>();

            AngerSignal anger = new AngerSignal(1, "Raised voice", true);
            Reducer reducer = new Reducer(1, "Counting backward", true);
            Stage stage = new Stage(1, "Recognizing triggers", true, 10);
            Stage stagea = new Stage(4, "Self-instruction to keep yourself calm", true, 9);
            Stage stageab = new Stage(5, "Self-rewarding for good effort", true, 7);
            var a = new Event();
            a.Id = 1;
            a.TimeOfEvent = new DateTime(2020, 10, 30, 8, 0, 0);
            a.Description = "blabla";
            a.AngerLevel = 4;
            a.InternalTriggers = "blabla";
            a.ExternalTriggers = "blabla";
            a.AngerSignals = new List<AngerSignal>
            {
                anger
            };
            a.Reducers = new List<Reducer>
            {
                reducer
            };
            a.SelfInstruction = "blablba";
            a.Consequences = "blblab";
            a.SelfEvaluation = new List<Stage>
            {
                stage,
                stagea,
                stageab
            };
            a.SelfCoaching = "blablab";
            testEvents.Add(a);

            Event b = new Event();
            AngerSignal angerb = new AngerSignal(2, "Headaches", true);
            Reducer reducerb = new Reducer(2, "Deep breathing", true);
            Stage stageb = new Stage(1, "Recognizing triggers", true, 10);
            Stage stageba = new Stage(1, "Recognizing triggers", true, 10);
            b.Id = 2;
            b.TimeOfEvent = new DateTime(2020, 11, 3, 11, 0, 0);
            b.Description = "blabla";
            b.AngerLevel = 5;
            b.InternalTriggers = "blabla";
            b.ExternalTriggers = "blabla";
            b.AngerSignals = new List<AngerSignal>
            {
                angerb
            };
            b.Reducers = new List<Reducer>
            {
                reducerb
            };
            b.SelfInstruction = "blablba";
            b.Consequences = "blblab";
            b.SelfEvaluation = new List<Stage>
            {
                stageb,
                stageba
            };
            b.SelfCoaching = "blablab";
            testEvents.Add(b);


            Event c = new Event();
            AngerSignal angerc = new AngerSignal(2, "Headaches", true);
            Reducer reducerc = new Reducer(1, "Counting backward", true);
            Stage stagec = new Stage(2, "Recognizing signals of anger", true, 11);
            Stage stageca = new Stage(3, "Using anger reducers", true, 12);
            c.Id = 3;
            c.TimeOfEvent = new DateTime(2020, 10, 1, 15, 0, 0);
            c.Description = "blabla";
            c.AngerLevel = 8;
            c.InternalTriggers = "blabla";
            c.ExternalTriggers = "blabla";
            c.AngerSignals = new List<AngerSignal>
            {
                angerc
            };
            c.Reducers = new List<Reducer>
            {
                reducerc
            };
            c.SelfInstruction = "blablba";
            c.Consequences = "blblab";
            c.SelfEvaluation = new List<Stage>
            {
                stagec,
                stageca
            };
            c.SelfCoaching = "blablab";
            testEvents.Add(c);

            Event d = new Event();
            AngerSignal angerd = new AngerSignal(2, "Headaches", true);
            Reducer reducerd = new Reducer(2, "Deep breathing", true);
            Stage staged = new Stage(2, "Recognizing signals of anger", true, 11);
            Stage stageda = new Stage(3, "Using anger reducers", true, 12);
            d.Id = 4;
            d.TimeOfEvent = new DateTime(2020, 10, 3, 11, 0, 0);
            d.Description = "blabla";
            d.AngerLevel = 8;
            d.InternalTriggers = "blabla";
            d.ExternalTriggers = "blabla";
            d.AngerSignals = new List<AngerSignal>
            {
                angerd
            };
            d.Reducers = new List<Reducer>
            {
                reducerd
            };
            d.SelfInstruction = "blablba";
            d.Consequences = "blblab";
            d.SelfEvaluation = new List<Stage>
            {
                staged,
                stageda
            };
            d.SelfCoaching = "blablab";
            testEvents.Add(d);


            return testEvents;

        }

    }
}

