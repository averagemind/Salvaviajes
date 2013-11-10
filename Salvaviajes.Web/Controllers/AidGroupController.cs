using System.Collections.Generic;
using System.Web.Http;

using Salvaviajes.DataObject;
using Salvaviajes.Web.Services;

namespace Salvaviajes.Web.Controllers
{
    public class AidGroupController : ApiController
    {
        // GET api/category
        public IEnumerable<AidGroup> Get()
        {
            return (new SMSServices()).GetSMSAidGroups();
        }
    }
}
