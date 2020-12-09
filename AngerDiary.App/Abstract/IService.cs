using System.Collections.Generic;

namespace AngerDiary.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }

        List<T> GetAllItems();

        void AddItem(T item);


    }
}
