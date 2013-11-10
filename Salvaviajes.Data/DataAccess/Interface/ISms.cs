using System.Collections.Generic;

using Salvaviajes.Data.DataModel;
using Salvaviajes.DataObject;

namespace Salvaviajes.Data.DataAccess.Interface
{
    public interface ISms
    {
        IEnumerable<IssueCategory> GetSMSCategories();

        IEnumerable<AidGroup> GetSMSAidGroups();

        IEnumerable<IssueSummary> GetSMSIssues();

        IssueDetails GetSMSIssue(int id);

        IEnumerable<IssueSummary> SearchIssues(string searchTerm);

        void Save(string serializedSms);
    }
}
