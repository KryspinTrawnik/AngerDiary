using AngerDiary.App.Common;
using AngerDiary.Domain.Entity;
using System.Collections.Generic;

namespace AngerDiary.App.Concrete
{
    class ReducerService : BaseService<Reducer>
    {
        public ReducerService()
        {
            Initialize();
        }
        public List<Reducer> GetNotUsedReducer()
        {
            List<Reducer> result = new List<Reducer>();
            foreach (var reducer in Items)
            {
                if (reducer.hasBeenUsed == false)
                {
                    result.Add(reducer);
                }

            }
            return result;
        }
        private void Initialize()
        {
            AddItem(new Reducer(1, "Counting backward", false));
            AddItem(new Reducer(2, "Deep breathing", false));
            AddItem(new Reducer(3, "Thinking ahead (if - consequences)", false));
            AddItem(new Reducer(4, "Positive visualisation", false));

        }
    }
}
