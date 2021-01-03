using AngerDiary.Domain.Entity;
using System.Collections.Generic;

namespace AngerDiary.App.Concrete
{
    public static class StageServiceHelper
    {
        public static List<Stage> PickFromInitialList(this List<Stage> list) 
        {
            list.Add(new Stage(1, "Recognizing triggers", false));
            list.Add(new Stage(2, "Recognizing signals of anger", false));
            list.Add(new Stage(3, "Using anger reducers", false));
            list.Add(new Stage(4, "Self-instruction to keep yourself calm", false));
            list.Add(new Stage(5, "Self-rewarding for good effort", false));
            list.Add(new Stage(6, "Looking at the good or bad consequences", false));
            
            return list;
        }

    }
}
