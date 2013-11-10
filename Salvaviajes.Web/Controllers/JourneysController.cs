using System.Web.Mvc;

using Salvaviajes.Web.Services;

namespace Salvaviajes.Web.Controllers
{
    public class JourneysController : Controller
    {
        private readonly JourneyServices _jny;

        public JourneysController()
        {
            _jny = new JourneyServices();
        }

        public ActionResult Index()
        {
            return View(_jny.GetJourneyStories());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
