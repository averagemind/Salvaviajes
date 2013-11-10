using System.Collections.Generic;

using Salvaviajes.DataObject;

namespace Salvaviajes.Data.DataAccess.Interface
{
    public interface IJourney
    {
        IEnumerable<JourneyStory> GetJourneyStories();
    }
}
