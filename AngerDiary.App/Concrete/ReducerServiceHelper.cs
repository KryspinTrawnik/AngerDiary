using AngerDiary.Domain.Entity;
using System.Collections.Generic;

namespace AngerDiary.App.Concrete
{
    public static class ReducerServiceHelper
    {
        public static List<Reducer> PickFromInitialList(this List<Reducer> list)
        {
            list.Add(new Reducer(1, "Counting backward", false));
            list.Add(new Reducer(2, "Deep breathing", false));
            list.Add(new Reducer(3, "Thinking ahead (if - consequences)", false));
            list.Add(new Reducer(4, "Positive visualisation", false));
            return list;
        }
    }
}
