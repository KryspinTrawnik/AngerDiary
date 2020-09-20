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
        public void AddNewSignal(int signalId, string signalName, bool hasBeenUsed)
        {
            AngerSignal angerSignal = new AngerSignal(signalId, signalName, hasBeenUsed);
            angerSignals.Add(angerSignal);
        }
        public List<AngerSignal> AddNotUsedSignal(bool hasBeenUsed)
        {
            List<AngerSignal> result = new List<AngerSignal>();
            foreach(var signal in angerSignals)
            {
                if (signal.Hasbeenused == false)
                {
                    result.Add(signal);
                }

            }
            return result;
        }

    }
}
