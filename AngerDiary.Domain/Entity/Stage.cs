using AngerDiary.Domain.Common;

namespace AngerDiary.Domain.Entity
{
    public class Stage : BaseEntity
    {
        public string Name { get; set; }

        public bool HasBeenUsed { get; set; }

        public int Value { get; set; }

        
        public Stage(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Stage(int id, string name, bool hasbeenused)
        {
            Id = id;
            Name = name;
            HasBeenUsed = hasbeenused;
        }
        public Stage(int id, string name, bool hasbeenused, int value)
        {
            Id = id;
            Name = name;
            HasBeenUsed = hasbeenused;
            Value = value;
        }
        public Stage()
        {
        }
    }
}