using System.Web.Mvc;

using Salvaviajes.Web.Services;

namespace Salvaviajes.Web.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly SMSServices _sms;

        public ResourcesController()
        {
            _sms = new SMSServices();
        }

        public ActionResult Index()
        {
            return View(_sms.GetSMSAidGroups());
        }
    }
}
