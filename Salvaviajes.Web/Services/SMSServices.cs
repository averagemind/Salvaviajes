using System.Collections.Generic;

using Salvaviajes.Business;
using Salvaviajes.Business.Interface;
using Salvaviajes.DataObject;

namespace Salvaviajes.Web.Services
{
    public class SMSServices
    {
        private readonly ISms _sms;

        public SMSServices(ISms sms)
        {
            _sms = sms;
        }

        public SMSServices() : this(new Sms())
        {
        }

        public IEnumerable<IssueCategory> GetIssueCategories()
        {
            return (new Sms()).GetSMSCategories();
        }

        public IEnumerable<IssueSummary> GetCurrentIssues()
        {
            return _sms.GetSMSIssues();
        }

        public IssueDetails GetIssue(int id)
        {
            return _sms.GetSMSIssue(id);
        }

        public IEnumerable<IssueSummary> SearchIssues(string searchTerm)
        {
            return _sms.SearchIssues(searchTerm);
        }

        public IEnumerable<AidGroup> GetSMSAidGroups()
        {
            return _sms.GetSMSAidGroups();
        }

        public void Save(string value)
        {
            _sms.Save(value);
        }
    }
}