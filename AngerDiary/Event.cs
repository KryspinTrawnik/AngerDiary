using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    public class Event
    {
        public int Id { get; set; }

        public DateTime Timeofevent { get; set; }

        public string Description { get; set; }

        public int  Angerlevel { get; set; }

        public string Internaltriggers { get; set; }

        public string Externaltriggers { get; set; }

        public  List <AngerSignal> Angersignals { get; set; }

        public List <Reducer> Reducers { get; set; }
       
        public string Selfinstruction { get; set; }

        public string Consequences { get; set; }

        public List <Stage> Selfevaluation { get; set; }

        public string Selfcoaching { get; set; }

        public Event(Event oldEvent)
        :this()
        {
            Id = oldEvent.Id;
            Timeofevent = oldEvent.Timeofevent;
            Description = oldEvent.Description;
            Angerlevel = oldEvent.Angerlevel;
            Internaltriggers = oldEvent.Internaltriggers;
            Externaltriggers = oldEvent.Externaltriggers;
            Angersignals = oldEvent.Angersignals;
            Reducers = oldEvent.Reducers;
            Selfinstruction = oldEvent.Selfinstruction;
            Consequences = oldEvent.Consequences;
            Selfevaluation = oldEvent.Selfevaluation;
            Selfcoaching = oldEvent.Selfcoaching;
        }

        public Event()
        {
            Angersignals = new List<AngerSignal>();
            Reducers = new List<Reducer>();
            Selfevaluation = new List<Stage>();

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

}
