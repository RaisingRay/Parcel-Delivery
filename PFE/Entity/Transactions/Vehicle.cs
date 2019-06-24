using System;
using PFE.Tiers.Data_Access_Layer;

namespace PFE.Entity.Transactions
{
    public class Vehicle
    {
        public Data id = new Data("vehicle_id");
        public Data license_plate = new Data("license_plate");
        public Data available = new Data("available");
        public Data VehicleDate = new Data("vehicle_date");
        public Data maxweight = new Data("max_weight");

        public Vehicle() { }
        public Vehicle(int id) { this.id.Value = id; }
        public Vehicle(int id, String license_plate, bool available, DateTime VehicleDate, float maxweight)
        {
            this.id.Value = id;
            this.license_plate.Value = license_plate;
            this.available.Value = available;
            this.VehicleDate.Value = VehicleDate;
            this.maxweight.Value = maxweight;
        }


    }
}