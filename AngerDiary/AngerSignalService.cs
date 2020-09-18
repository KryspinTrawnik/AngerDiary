using System;
using System.Collections.Generic;
using System.Text;

namespace AngerDiary
{
    class AngerSignalService
    {
        private List<AngerSignal> angerSignals;
        public AngerSignalService(List<AngerSignal> angerSignals)
        
        {
            this.angerSignals = angerSignals;
        }
        public void AddNewSignal(int id, string name, bool hasbeenused)
        {
            AngerSignal angerSignal = new AngerSignal(id, name, hasbeenused);
            angerSignals.Add(angerSignal);
        }
        public List<AngerSignal> AddNotUsedSignal(bool hasbeenused)
        {

        }

    }
}
