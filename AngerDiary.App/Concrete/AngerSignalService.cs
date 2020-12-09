using AngerDiary.App.Common;
using AngerDiary.Domain.Entity;
using System.Collections.Generic;

namespace AngerDiary.App.Concrete
{
    class AngerSignalService : BaseService<AngerSignal>
    {
        public AngerSignalService()
        {
            Initialize();
        }

        public List<AngerSignal> AddNotUsedSignal()
        {
            List<AngerSignal> result = new List<AngerSignal>();
            foreach (var signal in Items)
            {
                if (signal.HasBeenUsed == false)
                {
                    result.Add(signal);
                }

            }
            return result;
        }
        private void Initialize()
        {
            AddItem(new AngerSignal(1, "Raised voice", false));
            AddItem(new AngerSignal(2, "Headaches", false));
            AddItem(new AngerSignal(3, "Stomachaches", false));
            AddItem(new AngerSignal(4, "Increased heart rate", false));
            AddItem(new AngerSignal(5, "Raised blood pressure", false));
            AddItem(new AngerSignal(6, "Clenching your jaws or grinding your teeth", false));
            AddItem(new AngerSignal(7, "Clinched fists", false));
            AddItem(new AngerSignal(8, "Sweating, especially your palms", false));
            AddItem(new AngerSignal(9, "Feeling hot in the neck/face", false));

        }
    }
}
