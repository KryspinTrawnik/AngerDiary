using AngerDiary.App.Common;
using AngerDiary.Domain.Entity;
using System.Collections.Generic;

namespace AngerDiary.App.Concrete
{
    public class ReducerService : BaseService<Reducer>
    {
        public ReducerService()
        {
            Initialize();
        }
        public List<Reducer> GetNotUsedReducers()
        {
            List<Reducer> result = new List<Reducer>();
            foreach (var reducer in Items)
            {
                if (reducer.HasBeenUsed == false)
                {
                    result.Add(reducer);
                }

            }
            return result;
        }

        public Reducer GetReducerById(int id) => new List<Reducer>()
            .PickFromInitialList()
            .Find(reducer => reducer.Id == id);

        private void Initialize()
        {
            AddItem(new Reducer(1, "Counting backward", false));
            AddItem(new Reducer(2, "Deep breathing", false));
            AddItem(new Reducer(3, "Thinking ahead (if - consequences)", false));
            AddItem(new Reducer(4, "Positive visualisation", false));

        }
    }
}
