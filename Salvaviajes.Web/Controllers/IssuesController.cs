using System;
using System.Linq;
using System.Web.Mvc;

using Salvaviajes.Web.Models;
using Salvaviajes.Web.Services;

namespace Salvaviajes.Web.Controllers
{
    public class IssuesController : Controller
    {
        private readonly SMSServices _sms;

        public IssuesController()
        {
            _sms = new SMSServices();
        }

        public ActionResult Index()
        {
            return View(_sms.GetCurrentIssues());
        }

        public ActionResult Search(string searchTerm)
        {
            return PartialView("~/Views/Issues/SearchResults.cshtml", _sms.SearchIssues(searchTerm));
        }

        public ActionResult Create()
        {
            return View(InitLookupItems(0));
        }

        [HttpPost]
        public ActionResult Create(IssueModel model)
        {
            try
            {
                var now = DateTime.Now;
                var formattedDate = string.Format("{0}-{1}-{2} {3}:{4}:{5}", now.Month, now.Day, now.Year, now.Hour, now.Minute, now.Second);

                //IssueId,GUID,EncryptedFromInfo,ReportedOn,IssueDesc,CategoryId,City,State,Country,LocationDesc
                var serializedRequest = string.Format("0,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                                                         Guid.NewGuid(), Guid.NewGuid(),formattedDate,
                                                         model.IssueDescription,
                                                         model.SelectedCategory,
                                                         model.City, model.State, model.Country,
                                                         model.LocationDescription,
                                                         model.Severity);

                _sms.Save(serializedRequest);

                return Redirect();
            }
            catch
            {
                return Redirect();
            }
        }

        public ActionResult Edit(int id=0)
        {
            var model = InitLookupItems(id);

            if (id > 0)
            {
                var issueDetail = _sms.GetIssue(id);
                model.IssueId = issueDetail.IssueId;
                model.StreetName = issueDetail.StreetName;
                model.StreetNumber = issueDetail.StreetNumber;
                model.City = issueDetail.City;
                model.State = issueDetail.State;
                model.PostalCode = issueDetail.PostalCode;
                model.Country = issueDetail.Country;
                model.LocationDescription = issueDetail.LocationDescription;
                model.Severity = issueDetail.Severity.ToString();
                model.SelectedCategory = issueDetail.IssueCategory.ToString();
                model.IssueDescription = issueDetail.IssueDescription;
            }

            return View(model);
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

        #region helpers

        private IssueModel InitLookupItems(int id)
        {
            var issueCategories = _sms.GetIssueCategories();
            var model = new IssueModel
            {
                IssueId = id,
                IssueCategory = issueCategories,
                SelectedCategory = issueCategories.First().CategoryId.ToString(),
            };

            return model;
        }

        private ActionResult Redirect()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        #endregion
    }
}
