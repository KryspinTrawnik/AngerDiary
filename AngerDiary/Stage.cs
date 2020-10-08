namespace AngerDiary
{
    public class Stage
    {
        public int StageId { get; set; }

        public string StageName { get; set; }

        public bool HasBeenUsed { get; set; }

        public Stage(int id)
        {
            StageId = id;
        }
        public Stage(int id, string name)
        {
            StageId = id;
            StageName = name;
        }
        public Stage(int id, string name, bool hasbeenused)
        {
            StageId = id;
            StageName = name;
            HasBeenUsed = hasbeenused;
        }
        public Stage()
        {
        }
    }
}