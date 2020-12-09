using AngerDiary.Domain.Common;
using System;
using System.Collections.Generic;


namespace AngerDiary.Domain.Entity
{
    public class Event : BaseEntity
    {

        public DateTime TimeOfEvent { get; set; }

        public string Description { get; set; }

        public int AngerLevel { get; set; }

        public string InternalTriggers { get; set; }

        public string ExternalTriggers { get; set; }

        public List<AngerSignal> AngerSignals { get; set; }

        public List<Reducer> Reducers { get; set; }

        public string SelfInstruction { get; set; }

        public string Consequences { get; set; }

        public List<Stage> SelfEvaluation { get; set; }

        public string SelfCoaching { get; set; }

        public Event()
        {
            AngerSignals = new List<AngerSignal>();
            Reducers = new List<Reducer>();
            SelfEvaluation = new List<Stage>();

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

}
