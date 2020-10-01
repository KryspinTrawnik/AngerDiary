using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    class ReducerService
    {
        private List<Reducer> _reducers;

        public ReducerService()
        {
            this._reducers = new List<Reducer>();
        }
        public ReducerService(List<Reducer> reducers)
            : this()
        {
            this._reducers = reducers;
        }
        public void AddNewReducer(int reducerId, string reducerName, bool hasBeenUsed)
        {
            Reducer reducer = new Reducer(reducerId, reducerName, hasBeenUsed);
            _reducers.Add(reducer);
        }
        public List<Reducer> AddNotUsedReducer()
        {
            List<Reducer> result = new List<Reducer>();
            foreach (var reducer in _reducers)
            {
                if (reducer.hasBeenUsed == false)
                {
                    result.Add(reducer);
                }

            }
            return result;
        }
    }
}
