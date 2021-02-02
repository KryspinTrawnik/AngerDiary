using AngerDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngerDiary.App.Concrete
{
    public class TheMostUsedReducer
    {
        private MostUsedReducerItems mostUsedReducerItems;
        private ReducerService ReducerService;

        public TheMostUsedReducer()
        {
            mostUsedReducerItems = new MostUsedReducerItems();
            ReducerService = new ReducerService();
        }
        public Reducer FindMostUsedReducer(EventService eventService)
        {
            foreach (Event _event in eventService.Items)
            {
                for (int i = 1; _event.Reducers.Count > i; i++)
                {
                    mostUsedReducerItems.IdCount[_event.Reducers[i].Id - 1].Item2++;
                }
            }

           mostUsedReducerItems.IdCount = mostUsedReducerItems.IdCount.ToList().OrderBy(x => x.Item2).ToArray();
           mostUsedReducerItems.Id = mostUsedReducerItems.IdCount.ToList()
                .First().Item1;
            mostUsedReducerItems.MostUsedReducer = ReducerService.GetReducerById(mostUsedReducerItems.Id);

            return mostUsedReducerItems.MostUsedReducer;

        }
    }

}
