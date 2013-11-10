using System;

namespace Salvaviajes.Data.DataModel
{
    public partial class Location
    {
        public string StreetAddress
        {
            get
            {
                var address = string.IsNullOrWhiteSpace(StreetNumber) ? string.Empty : StreetNumber.Trim();
                address = string.Format("{0} {1}", address, string.IsNullOrWhiteSpace(StreetName) ? string.Empty : StreetName.Trim());

                return address.Trim();
            }
        }

        public string CityStateZip
        {
            get
            {
                var address = string.IsNullOrWhiteSpace(City) ? string.Empty : string.Format("{0},", City.Trim());
                address = string.Format("{0} {1}", address, string.IsNullOrWhiteSpace(State) ? string.Empty : State.Trim());
                address = string.Format("{0} {1}", address, string.IsNullOrWhiteSpace(PostalCode) ? string.Empty : PostalCode.Trim());

                return address.Trim().TrimEnd(',');
            }
        }

        public string CountryDisplay
        {
            get
            {
                return string.IsNullOrWhiteSpace(Country) ? string.Empty : Country.Trim();
            }
        }
    }
}
