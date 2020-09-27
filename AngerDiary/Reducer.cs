using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    class Reducer
    {
        public int Reducerid { get; set; }

        public string Reducername { get; set; }

        public bool Hasbeenused { get; set; }

        public Reducer(int id)
        {
            Reducerid = id;
        }
        public Reducer(int id, string name)
        {
           Reducerid = id;
           Reducername = name;
        }
        public Reducer(int id, string name, bool hasbeenused)
        {
            Reducerid= id;
            Reducername = name;
            Hasbeenused = hasbeenused;
        }
        public Reducer()
        {
        }
    }
}
