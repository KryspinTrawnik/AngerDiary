using AngerDiary.Domain.Common;

namespace AngerDiary.Domain.Entity
{
    public class Reducer : BaseEntity
    {
        public string Name { get; set; }

        public bool HasBeenUsed { get; set; }

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
            Id = id;
            Name = name;
            HasBeenUsed = hasbeenused;
        }
        public Reducer()
        {
        }
    }
}
