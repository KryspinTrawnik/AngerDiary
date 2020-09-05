using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    public class EventFeatures
    {
        public void AddAngerSignals ()
        {
            string[] signals = {"Raised voice", "Headaches", "Stomachaches","Increased heart rate",
            "Raised blood pressure", "Clenching your jaws or grinding your teeth", "Clinched fists", 
              "Sweating, especially your palms", "feeling hot in the neck/face"};
            List<string> angerSignals = new List<string>(signals);
            foreach(string var in angerSignals)
            {
                Console.WriteLine(angerSignals.IndexOf(var));
            }
            while(true)
            {

            }
        }
    }
}
