using AngerDiary.Domain.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AngerDiary.App.Concrete
{
    public class FileService
    {
        private const string ItemsFilePath = @"Items.txt";
        private const string RaportsFilePath = @"Raports.txt";
        private const string Questions = @"C:\Users\Dell\Desktop\Kurs Zostan Programista NET\AngerDiary2\AngerDiary\Questions.csv";
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
        public void SaveRaport(EventService eventService, RaportService raportService)
        {
            if (eventService.Items.Count % 5 == 0)
            {
                
                List<Raport> Raports = raportService.CreateAndAddRaport(eventService);
                using StreamWriter sw = new StreamWriter(RaportsFilePath, false);
                using JsonWriter writer = new JsonTextWriter(sw);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, Raports);
            }
        }
        public void UploadRaports(RaportService raportService)
        {
            if(File.Exists(RaportsFilePath))
            {
                string ReadList = File.ReadAllText(RaportsFilePath);
                var convertedRaports = JsonConvert.DeserializeObject<List<Raport>>(ReadList);
            }
        }

        public List<string> ReadQuestions()
        {
            var read = File.ReadAllLines(Questions);
            List<string> listOfQuestions = new List<string>();
            foreach (string str in read)
            {
                string newstr = str.Trim('"');
                listOfQuestions.Add(newstr);
            }
            return listOfQuestions;
        }
    }
}