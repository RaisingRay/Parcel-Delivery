using System;
using PFE.Entity.Authentification;
using PFE.Tiers.Data_Access_Layer;


namespace PFE.Entity.HumanRessources
{
    public class Customer:Person
    {
        public Data ctmId =new Data("customer_id");
        public Data job = new Data("jobe");
        public Data ctmEditedDate = new Data("edited_date");

        public Customer() { }
        public Customer(int ctmId) { this.ctmId.Value = ctmId; }
        public Customer(int ctmId,String job,DateTime ctmEditedDate)
        {
            this.ctmId.Value = ctmId;
            this.job.Value = job;
            this.ctmEditedDate.Value = ctmEditedDate;
        }
        public Customer(
            int ctmId,
            String job,
            DateTime ctmEditedDate,
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
            ) : base(cin, firstName, lastName, phoneNumber, PeditedDate, address, id, email, password, salt, createdDate, editedDate, role, status)
        {
            this.ctmId.Value = ctmId;
            this.job.Value = job;
            this.ctmEditedDate.Value = ctmEditedDate;
        }
    }
}