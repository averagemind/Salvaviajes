using System;
using System.Collections.Generic;
using System.Linq;

using Salvaviajes.Data.DataAccess.Interface;
using dm=Salvaviajes.Data.DataModel;
using Salvaviajes.DataObject;

namespace Salvaviajes.Data.DataAccess
{
    public class Sms : ISms
    {
        public IEnumerable<IssueCategory> GetSMSCategories()
        {
            using (var context = new dm.SalvaviajesEntities())
            {
                return (from c in context.SMSCategories
                        orderby c.CategoryId descending
                        select new IssueCategory
                        {
                            CategoryId = c.CategoryId,
                            CategoryName = c.CategoryName,
                        }
                        ).ToList();
            }
        }

        public IEnumerable<AidGroup> GetSMSAidGroups()
        {
            using (var context = new dm.SalvaviajesEntities())
            {
                return (from g in context.SMSAidGroups.Include("Location")
                        orderby g.AidGroupName
                        select g)
                        .ToList()
                        .Select(g => new AidGroup
                        {
                            AidGroupName = g.AidGroupName,
                            StreetAddress = g.Location.StreetAddress,
                            CityStateZip = g.Location.CityStateZip,
                            Country = g.Location.Country,
                        });
            }
        }

        public IssueDetails GetSMSIssue(int id)
        {
            using (var context = new dm.SalvaviajesEntities())
            {
                return (from i in context.SMSIssues
                        join l in context.Locations on i.LocationId equals l.LocationId
                        where i.IssueId == id
                        select new IssueDetails
                        {
                            IssueId = i.IssueId,
                            StreetName = l.StreetName,
                            StreetNumber = l.StreetNumber,
                            City = l.City,
                            State = l.State,
                            PostalCode = l.PostalCode,
                            Country = l.Country,
                            LocationDescription = l.Description,
                            Severity = i.LikertScale.HasValue ? i.LikertScale.Value : 0,
                            IssueCategory = i.CategoryId.HasValue ? i.CategoryId.Value : 0,
                            IssueDescription = i.Description,

                        }).SingleOrDefault();
            }
        }

        public IEnumerable<IssueSummary> GetSMSIssues()
        {
            using (var context = new dm.SalvaviajesEntities())
            {
                return (from i in context.SMSIssues
                        join l in context.Locations on i.LocationId equals l.LocationId
                        join c in context.SMSCategories on i.CategoryId equals c.CategoryId
                        select new IssueSummary
                        {
                            IssueId = i.IssueId,
                            Lat = l.Lat.HasValue ? l.Lat.Value : 0,
                            Lon = l.Lon.HasValue ? l.Lon.Value : 0,
                            LocationDescription = l.Description,
                            Timestamp = i.ReportedOn,
                            CategoryDescription = c.CategoryName,
                            LikertScale = i.LikertScale.HasValue ? i.LikertScale.Value : 0,
                            IssueDescription = i.Description,

                        }).ToList();
            }
        }

        public IEnumerable<IssueSummary> SearchIssues(string searchTerm)
        {
            return GetSMSIssues().Where(i => i.IssueDescription.IndexOf(searchTerm, StringComparison.InvariantCultureIgnoreCase) > -1).ToList();
        }

        public void Save(string serializedSms)
        {
            using (var context = new dm.SalvaviajesEntities())
            {
                try
                {
                    var values = serializedSms.Split(',');
                    var issue = new dm.SMSIssue
                    {
                        SMSGuid = values[1],
                        ReportedFrom = values[2],
                        ReportedOn = Convert.ToDateTime(values[3]),
                        Description = values[4], // confirming an issue could include a new description
                        CategoryId = Convert.ToInt32(values[5]), // the original issue could be confirmed to a different category
                        LoggedOn = DateTime.Now,
                        LikertScale = Convert.ToInt32(values[10]),
                    };

                    var parentIssueId = Convert.ToInt32(values[0]);
                    if (parentIssueId > 0)
                    {
                        // confirming original reported issue
                        issue.ParentIssueId = parentIssueId;
                    }
                    else
                    {
                        var location = new dm.Location
                        {
                            City = values[6],
                            State = values[7],
                            Country = values[8],
                            Description = values[9],
                            Curated = false,
                        };
                        context.Locations.Add(location);
                        context.SaveChanges();

                        issue.LocationId = location.LocationId;
                    }

                    context.SMSIssues.Add(issue);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var errorlog = new dm.SMSErrorLog
                    {
                        ErrorMessage = ex.Message,
                        LoggedOn = DateTime.Now,
                    };

                    context.SMSErrorLogs.Add(errorlog);
                    context.SaveChanges();
                }
            }
        }
    }
}
