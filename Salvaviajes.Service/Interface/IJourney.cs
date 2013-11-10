using System.Collections.Generic;

using Salvaviajes.DataObject;

namespace Salvaviajes.Business.Interface
{
    public interface IJourney
    {
        IEnumerable<JourneyStory> GetJourneyStories();
    }
}
