using AngerDiary.Domain.Common;

namespace AngerDiary.Domain.Entity
{
    public class Stage : BaseEntity
    {
        public string Name { get; set; }

        public bool HasBeenUsed { get; set; }

        public Stage(int id)
        {
            Id = id;
        }
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
        public Stage()
        {
        }
    }
}