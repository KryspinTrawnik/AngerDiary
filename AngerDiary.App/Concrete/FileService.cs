using AngerDiary;
using AngerDiary.App.Concrete;
using AngerDiary.Domain;
using AngerDiary.Domain.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AngerDiary.App.Concrete
{
    public class FileService
    {
        private const string ItemsFilePath = @"Items.txt";
        public FileService()
        {
            
        }

        public void SavingToFile(EventService eventService)
        {
            using StreamWriter sw = new StreamWriter(ItemsFilePath, false);
            using JsonWriter writer = new JsonTextWriter(sw);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, eventService.Items);
        }

        public void UploadItems(EventService eventService)
        {
            if (File.Exists(ItemsFilePath))
            {
                string ReadList = File.ReadAllText(ItemsFilePath);
                var ConvertedListOfEvents = JsonConvert.DeserializeObject<List<Event>>(ReadList);

                eventService.AddRangeOfEvents(ConvertedListOfEvents);
            }
        }
        public void MonthlyRaport(EventProgressItems eventProgressItems)
        {

        }
    }
}