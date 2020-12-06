using AngerDiary.App.Abstract;
using AngerDiary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }
        public void AddItem(T item)
        {
            Items.Add(item);
            
        }

        public List<T> GetAllItems()
        {
            return Items;
        }
    }
}
