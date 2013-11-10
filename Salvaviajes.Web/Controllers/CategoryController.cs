using System.Collections.Generic;
using System.Web.Http;

using Salvaviajes.DataObject;
using Salvaviajes.Web.Services;

namespace Salvaviajes.Web.Controllers
{
    public class CategoryController : ApiController
    {
        // GET api/category
        public IEnumerable<IssueCategory> Get()
        {
            return (new SMSServices()).GetIssueCategories();
        }
    }
}
