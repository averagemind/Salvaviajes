using System.Collections.Generic;

using Salvaviajes.DataObject;

using bi = Salvaviajes.Business.Interface;
using da = Salvaviajes.Data.DataAccess;
using di = Salvaviajes.Data.DataAccess.Interface;

namespace Salvaviajes.Business
{
    public class Sms : bi.ISms
    {
        private readonly di.ISms _da;

        public Sms(di.ISms da)
        {
            _da = da;
        }

        public Sms()
            : this(new da.Sms())
        {
        }

        public IEnumerable<IssueCategory> GetSMSCategories()
        {
            return _da.GetSMSCategories();
        }

        public IEnumerable<AidGroup> GetSMSAidGroups()
        {
            return _da.GetSMSAidGroups();
        }

        public IEnumerable<IssueSummary> GetSMSIssues()
        {
            return _da.GetSMSIssues();
        }

        public IssueDetails GetSMSIssue(int id)
        {
            return _da.GetSMSIssue(id);
        }

        public IEnumerable<IssueSummary> SearchIssues(string searchTerm)
        {
            return _da.SearchIssues(searchTerm);
        }

        public void Save(string serializedSms)
        {
            _da.Save(serializedSms);
        }
    }
}
