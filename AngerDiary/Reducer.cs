using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    public class Reducer
    {
        public int reducerId { get; set; }

        public string reducerName { get; set; }

        public bool hasBeenUsed { get; set; }

        public Reducer(int id)
        {
            reducerId = id;
        }
        public Reducer(int id, string name)
        {
           reducerId = id;
           reducerName = name;
        }
        public Reducer(int id, string name, bool hasbeenused)
        {
            reducerId= id;
            reducerName = name;
            hasBeenUsed = hasbeenused;
        }
        public Reducer()
        {
        }
    }
}
