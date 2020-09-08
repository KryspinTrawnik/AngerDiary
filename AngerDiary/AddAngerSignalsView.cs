using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    public class AddAngerSignalsView
    {


        public void AddAngerSignals()
        {
            string[] signals = {"Raised voice", "Headaches", "Stomachaches","Increased heart rate",
            "Raised blood pressure", "Clenching your jaws or grinding your teeth", "Clinched fists",
              "Sweating, especially your palms", "feeling hot in the neck/face"};
            AngerSignalService angersignalService = new AngerSignalService();
            angersignalService = Initialize(angersignalService); ;


        }

        private static AngerSignalService Initialize(AngerSignalService angersignalService)
        {
            angersignalService.AddNewSignal(1, "Raised voice");
            angersignalService.AddNewSignal(2, "Headaches");
            angersignalService.AddNewSignal(3, "Stomachaches");
            angersignalService.AddNewSignal(4, "Increased heart rate");
            angersignalService.AddNewSignal(5, "Raised blood pressure");
            angersignalService.AddNewSignal(6, "Clenching your jaws or grinding your teeth");
            angersignalService.AddNewSignal(7, "Clinched fists");
            angersignalService.AddNewSignal(8, "Sweating, especially your palms");
            angersignalService.AddNewSignal(9, "Feeling hot in the neck/face");

            return angersignalService;
        }
    }
}
