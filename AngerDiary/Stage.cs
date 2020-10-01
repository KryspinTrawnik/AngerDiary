namespace AngerDiary
{
    public class Stage
    {
        public int stageId { get; set; }

        public string stageName { get; set; }

        public bool hasBeenUsed { get; set; }

        public Stage(int id)
        {
            stageId = id;
        }
        public Stage(int id, string name)
        {
            stageId = id;
            stageName = name;
        }
        public Stage(int id, string name, bool hasbeenused)
        {
            stageId = id;
            stageName = name;
            hasBeenUsed = hasbeenused;
        }
        public Stage()
        {
        }
    }
}