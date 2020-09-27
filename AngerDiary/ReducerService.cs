using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    class ReducerService
    {
        private List<Reducer> reducers;

        public ReducerService()
        {
            this.reducers = new List<Reducer>();
        }
        public ReducerService(List<Reducer> reducers)
            : this()
        {
            this.reducers = reducers;
        }
        public void AddNewReducer(int reducerId, string reducerName, bool hasBeenUsed)
        {
            Reducer reducer = new Reducer(reducerId, reducerName, hasBeenUsed);
            reducers.Add(reducer);
        }
        public List<Reducer> AddNotUsedReducer()
        {
            List<Reducer> result = new List<Reducer>();
            foreach (var reducer in reducers)
            {
                if (reducer.Hasbeenused == false)
                {
                    result.Add(reducer);
                }

            }
            return result;
        }
    }
}
