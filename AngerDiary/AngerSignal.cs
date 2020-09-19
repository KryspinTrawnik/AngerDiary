using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    public class AngerSignal
    {

       public int Signalid { get; set; }

       public string SignalName { get; set; }

        public bool Hasbeenused { get; set; }

        public AngerSignal(int id)
        {
            Signalid = id;
        }
        public AngerSignal(int id, string name)
        {
            Signalid = id;
            SignalName = name;
        }
        public AngerSignal(int id, string name, bool hasbeenused)
        {
            Signalid = id;
            SignalName = name;
            Hasbeenused = hasbeenused;
        }
        public AngerSignal()
        {
        }
    }
}
