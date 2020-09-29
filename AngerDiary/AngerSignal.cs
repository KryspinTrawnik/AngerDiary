using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    public class AngerSignal
    {

       public int Signalid { get; set; }

       public string Signalname { get; set; }

        public bool HasBeenUsed { get; set; }

        public AngerSignal(int id)
        {
            Signalid = id;
        }
        public AngerSignal(int id, string name)
        {
            Signalid = id;
            Signalname = name;
        }
        public AngerSignal(int id, string name, bool hasbeenused)
        {
            Signalid = id;
            Signalname = name;
            HasBeenUsed = hasbeenused;
        }
        public AngerSignal()
        {
        }
    }
}
