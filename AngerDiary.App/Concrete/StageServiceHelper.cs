using AngerDiary.Domain.Entity;
using System.Collections.Generic;

namespace AngerDiary.App.Concrete
{
    public static class StageServiceHelper
    {
        public static List<Stage> PickFromInitialList(this List<Stage> list) 
        {
            list.Add(new Stage(1, "Recognizing triggers", false, 10));
            list.Add(new Stage(2, "Recognizing signals of anger", false, 11));
            list.Add(new Stage(3, "Using anger reducers", false, 12));
            list.Add(new Stage(4, "Self-instruction to keep yourself calm", false, 9));
            list.Add(new Stage(5, "Self-rewarding for good effort", false, 7));
            list.Add(new Stage(6, "Looking at the good or bad consequences", false, 8));
            
            return list;
        }

    }
}
