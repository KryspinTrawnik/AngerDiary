﻿using System;
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
        public void AddNewSignal(int id, string name)
        {
            AngerSignal angerSignal = new AngerSignal(id, name);
            angerSignals.Add(angerSignal);
        }


    }
}