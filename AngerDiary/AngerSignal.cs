using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    public class AngerSignal
    {

        int Signalid { get; set; }

        string SignalName { get; set; }

        bool Hasbeenused { get; set; }

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
