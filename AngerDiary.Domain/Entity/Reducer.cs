using AngerDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary.Domain.Entity
{
    public class Reducer : BaseEntity
    {
        public string Name { get; set; }

        public bool hasBeenUsed { get; set; }

        public Reducer(int id)
        {
            Id = id;
        }
        public Reducer(int id, string name)
        {
           Id = id;
           Name = name;
        }
        public Reducer(int id, string name, bool hasbeenused)
        {
            Id= id;
            Name = name;
            hasBeenUsed = hasbeenused;
        }
        public Reducer()
        {
        }
    }
}
