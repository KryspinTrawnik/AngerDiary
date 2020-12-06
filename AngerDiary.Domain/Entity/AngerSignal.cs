using AngerDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary.Domain.Entity
{
    public class AngerSignal : BaseEntity
    {
       public string Name { get; set; }

        public bool HasBeenUsed { get; set; }

        public AngerSignal(int id)
        {
            Id = id;
        }
        public AngerSignal(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public AngerSignal(int id, string name, bool hasbeenused)
        {
            Id = id;
            Name = name;
            HasBeenUsed = hasbeenused;
        }
        public AngerSignal()
        {
        }
    }
}
