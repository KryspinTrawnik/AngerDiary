using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngerDiary.App.Concrete
{
    public class TheMostUsedReducer
    {
        private MostUsedReducerItems MostUsedReducerItems;
        private ReducerService ReducerService;

        public TheMostUsedReducer()
        {
            MostUsedReducerItems = new MostUsedReducerItems();
            ReducerService = new ReducerService();
        }
        public Reducer FindMostUsedReducer(EventService eventService)
        {
            foreach (Event _event in eventService.Items)
            {
                for (int i = 1; _event.Reducers.Count > i; i++)
                {
                    MostUsedReducerItems.IdCount[_event.Reducers[i].Id - 1].Item2++;
                }
            }

           MostUsedReducerItems.IdCount = MostUsedReducerItems.IdCount.ToList().OrderBy(x => x.Item2).ToArray();
           MostUsedReducerItems.Id = MostUsedReducerItems.IdCount.ToList()
                .First().Item1;
            MostUsedReducerItems.MostUsedReducer = ReducerService.GetReducerById(MostUsedReducerItems.Id);

            return MostUsedReducerItems.MostUsedReducer;

        }
    }

}
