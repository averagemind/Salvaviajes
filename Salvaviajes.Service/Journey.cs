using System.Collections.Generic;

using Salvaviajes.DataObject;

using bi = Salvaviajes.Business.Interface;
using da = Salvaviajes.Data.DataAccess;
using di = Salvaviajes.Data.DataAccess.Interface;

namespace Salvaviajes.Business
{
    public class Journey : bi.IJourney
    {
        private readonly di.IJourney _da;

        public Journey(di.IJourney da)
        {
            _da = da;
        }

        public Journey()
            : this(new da.Journey())
        {
        }

        public IEnumerable<JourneyStory> GetJourneyStories()
        {
            return _da.GetJourneyStories();
        }
    }
}
