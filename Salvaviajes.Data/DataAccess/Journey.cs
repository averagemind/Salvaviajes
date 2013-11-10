using System.Collections.Generic;
using System.Linq;

using Salvaviajes.Data.DataAccess.Interface;
using Salvaviajes.DataObject;
using dm = Salvaviajes.Data.DataModel;

namespace Salvaviajes.Data.DataAccess
{
    public class Journey : IJourney
    {
        public IEnumerable<JourneyStory> GetJourneyStories()
        {
            using (var context = new dm.SalvaviajesEntities())
            {
                return (from c in context.Documentaries
                        orderby c.Title
                        select new JourneyStory
                        {
                            Title = c.Title,
                            Content = c.Content,
                            ContentPath = c.ContentPath,
                        }
                        ).ToList();
            }
        }
    }
}
