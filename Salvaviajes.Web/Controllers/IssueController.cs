using System.Collections.Generic;
using System.Web.Http;

using Salvaviajes.DataObject;
using Salvaviajes.Web.Services;

namespace Salvaviajes.Web.Controllers
{
    public class IssueController : ApiController
    {
        private readonly SMSServices _sms;

        public IssueController()
        {
            _sms = new SMSServices();
        }

        public IEnumerable<IssueSummary> Get()
        {
            return _sms.GetCurrentIssues();
        }

        public void Post([FromBody]string value)
        {
            _sms.Save(value);
        }
    }
}
