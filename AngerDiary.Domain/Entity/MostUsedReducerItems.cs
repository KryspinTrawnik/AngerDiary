using AngerDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary.Domain.Entity
{
    public class MostUsedReducerItems : BaseEntity
    {

        public Reducer MostUsedReducer { get; set; }

        public (int, int)[] IdCount { get; set; }

        public MostUsedReducerItems()
        {
            IdCount = new (int, int)[] { (1, 0), (2, 0), (3, 0), (4, 0) };
        }
    }
}
