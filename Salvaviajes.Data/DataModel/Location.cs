//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Salvaviajes.Data.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        public int LocationId { get; set; }
        public Nullable<decimal> Lat { get; set; }
        public Nullable<decimal> Lon { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Curated { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
    }
}