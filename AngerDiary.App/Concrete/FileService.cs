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
        private const string ItemsFilePath = @"C: \Users\Dell\Desktop\Kurs Zostan Programista NET\Json\Items.txt";
        public FileService()
        {
            
        }

        public void SavingToFile(EventService eventService)
        {
            using StreamWriter sw = new StreamWriter(ItemsFilePath);
            using JsonWriter writer = new JsonTextWriter(sw);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, eventService.Items);
        }

        public void UploadItems(EventService eventService)
        {
            JsonSerializer serializier = new JsonSerializer();
           string ReadList = File.ReadAllText(ItemsFilePath);
           var ConvertedListOfEvents = JsonConvert.DeserializeObject<List<Event>>(ReadList);

            eventService.AddRangeOfEvents(ConvertedListOfEvents);
        }
    }
}