
namespace Salvaviajes.DataObject
{
    public class IssueDetails
    {
        public int IssueId { get; set; }

        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string LocationDescription { get; set; }

        public int Severity { get; set; }
        public int IssueCategory { get; set; }
        public string IssueDescription { get; set; }
    }
}
