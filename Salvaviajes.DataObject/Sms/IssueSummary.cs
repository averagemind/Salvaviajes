using System;

namespace Salvaviajes.DataObject
{
    public class IssueSummary
    {
        public int IssueId { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string LocationDescription { get; set; }
        public DateTime Timestamp { get; set; }
        public string CategoryDescription { get; set; }
        public int LikertScale { get; set; }
        public string IssueDescription { get; set; }
    }
}
