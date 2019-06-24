using System;
using PFE.Entity.Authentification;
using PFE.Entity.Transactions;
using PFE.Tiers.Data_Access_Layer;

namespace PFE.Entity.HumanRessources
{
    public class Driver:Employee
    {
        public Data dvrId = new Data("driver_id");
        public Data driverType = new Data("driver_type");
        public Data available = new Data("available");
        public Data dvrEditedDate = new Data("edited_date");
        public Data vehicle = new Data("vehicle_id");

        public Driver() { }
        public Driver(int dvrId) { this.dvrId.Value = dvrId; }
        public Driver(int dvrId,String driverType,bool available,DateTime dvrEditedDate)
        {
            this.dvrId.Value = dvrId;
            this.driverType.Value = driverType;
            this.available.Value = available;
            this.dvrEditedDate.Value = dvrEditedDate;
        }

        public Driver(
            int dvrId,
            String driverType,
            bool available,
            DateTime dvrEditedDate,
            Vehicle vehicle,
            int empId,
            String Title,
            DateTime hireDate,
            DateTime empEditedDate,
            int cin,
            String firstName,
            String lastName,
            int phoneNumber,
            DateTime PeditedDate,
            Address address,
            int id,
            String email,
            String password,
            String salt,
            DateTime createdDate,
            DateTime editedDate,
            UserRole role,
            UserStatus status
            ):base(empId,Title,hireDate,empEditedDate, cin, firstName, lastName, phoneNumber, PeditedDate, address, id, email, password, salt, createdDate, editedDate, role, status)
        {
            this.dvrId.Value = dvrId;
            this.driverType.Value = driverType;
            this.available.Value = available;
            this.dvrEditedDate.Value = dvrEditedDate;
            this.vehicle.Value = vehicle;
        }
    }
}