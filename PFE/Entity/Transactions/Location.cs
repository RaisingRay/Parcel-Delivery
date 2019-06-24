using System;
using PFE.Tiers.Data_Access_Layer;

namespace PFE.Entity.Transactions
{
    public class Location
    {
        public Data id = new Data("location_id");
        public Data state = new Data("state");
        public Data city = new Data("city");
        public Data address = new Data("address_line");
        public Data zipCode = new Data("zip_code");
        public Data Latitude = new Data("Latitude");
        public Data Longitude= new Data("Longitude");

        public Location() { }
        public Location(int id) { this.id.Value = id; }
        public Location(int id, String state, String city, String address, int zipCode,double Latitude,double Longitude)
        {
            this.id.Value = id;
            this.state.Value = state;
            this.city.Value = city;
            this.address.Value = address;
            this.zipCode.Value = zipCode;
            this.Latitude.Value = Latitude;
            this.Longitude.Value = Longitude;
        }
    }
}