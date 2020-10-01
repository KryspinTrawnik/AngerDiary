using System.Collections.Generic;

namespace AngerDiary
{
    class AngerSignalService
    {
        private List<AngerSignal> _angerSignals;
        
        public AngerSignalService()
        {
            this._angerSignals = new List<AngerSignal>();
        }
        public AngerSignalService(List<AngerSignal> angerSignals)
            :this()
        {
            this._angerSignals = angerSignals;
        }
        public void AddNewSignal(int signalId, string signalName, bool hasBeenUsed)
        {
            AngerSignal angerSignal = new AngerSignal(signalId, signalName, hasBeenUsed);
            _angerSignals.Add(angerSignal);
        }
        public List<AngerSignal> AddNotUsedSignal()
        {
            List<AngerSignal> result = new List<AngerSignal>();
            foreach(var signal in _angerSignals)
            {
                if (signal.HasBeenUsed == false)
                {
                    result.Add(signal);
                }

            }
            return result;
        }

    }
}
