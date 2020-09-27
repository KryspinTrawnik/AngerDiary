using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    public class Event
    {
        public DateTime Timeofevent { get; set; }

        public string Description { get; set; }

        public int  Angerlevel { get; set; }

        public string Internaltriggers { get; set; }

        public string Externaltriggers { get; set; }

        public  List <AngerSignal> Angersignals { get; set; }

        public List <Reducer> Reducers { get; set; }
       
        public string Positivetought { get; set; }

        public string Consequences { get; set; }

        public int Selfevaluation { get; set; }

        public string Selfcoaching { get; set; }
    }
}
