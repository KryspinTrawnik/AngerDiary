using System.Collections.Generic;

namespace AngerDiary
{
    class AngerSignalService
    {
        private List<AngerSignal> angerSignals;
        public AngerSignalService()
        { 
        
        }
        public AngerSignalService(List<AngerSignal> angerSignals)
        
        {
            this.angerSignals = angerSignals;
        }
        public void AddNewSignal(int Signalid, string Signalname, bool hasbeenused)
        {
            AngerSignal angerSignal = new AngerSignal(Signalid, Signalname, hasbeenused);
            angerSignals.Add(angerSignal);
        }
        public List<AngerSignal> AddNotUsedSignal(bool hasbeenused)
        {
            List<AngerSignal> result = new List<AngerSignal>();
            foreach(var signal in angerSignals)
            {
                if (hasbeenused == false)
                {
                    result.Add(signal);
                }

            }
            return result;
        }

    }
}
