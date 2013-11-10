using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using Salvaviajes.DataObject;

namespace Salvaviajes.Web.Models
{
    public class IssueModel
    {
        [HiddenInput]
        public int IssueId { get; set; }

        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Area Description or Landmarks")]
        public string LocationDescription { get; set; }

        [Required]
        [Display(Name = "Issue Categories")]
        public IEnumerable<IssueCategory> IssueCategory { get; set; }

        [Display(Name = "Severity")]
        public string Severity { get; set; }

        [HiddenInput]
        public string SelectedCategory { get; set; }

        [Required]
        [Display(Name = "Issue Description")]
        public string IssueDescription { get; set; }
    }
}