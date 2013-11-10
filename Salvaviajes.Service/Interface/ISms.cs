using System.Collections.Generic;

using Salvaviajes.DataObject;

namespace Salvaviajes.Business.Interface
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
