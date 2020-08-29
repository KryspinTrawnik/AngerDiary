using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace AngerDiary
{
    public class ItemService
    {
        public List<Item> Items { get; set; }
        public ItemService()
        {
            Items = new List<Item>();

        }
        public DateTime AddNewEventView()
        {
            string giventime;
            Item item = new Item();
            Console.WriteLine("Please, enter date and time of a new event");
            Console.WriteLine("Please, use format YYYY/MM/DD");
            giventime = Console.ReadLine();
            DateTime timeofevent;
            DateTime.TryParse(giventime, out timeofevent);
            item.Timeofevent = timeofevent;

           
            return timeofevent;
        }
        public string AddNewEvent()
        {
            Item item = new Item();
            Console.WriteLine("Describe the event:");
            string description = Console.ReadLine();
            item.Descriptionofevent = description;

            Console.WriteLine("wh");
                return description;
        }
    }
}
