using System.Collections.Generic;

using Salvaviajes.Business;
using Salvaviajes.Business.Interface;
using Salvaviajes.DataObject;

namespace Salvaviajes.Web.Services
{
    public class JourneyServices
    {
        private readonly IJourney _jny;

        public JourneyServices(IJourney jny)
        {
            _jny = jny;
        }

        public JourneyServices()
            : this(new Journey())
        {
        }

        public IEnumerable<JourneyStory> GetJourneyStories()
        {
            return _jny.GetJourneyStories();
        }
    }
}