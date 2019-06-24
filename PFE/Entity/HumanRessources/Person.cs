using System;
using PFE.Entity.Authentification;
using PFE.Tiers.Data_Access_Layer;

namespace PFE.Entity.HumanRessources
{
    public class Person : User
    {
        public Data cin =new Data("cin");
        public Data firstName = new Data("first_name");
        public Data lastName = new Data("last_name");
        public Data phonenumber = new Data("phone_number");
        public Data PeditedDate = new Data("edited_date");
        public Data address = new Data("address_id");

        public Person() { }
        public Person(int cin) { this.cin.Value = cin; }
        public Person(int cin, String firstName, String lastName, int phonenumber, DateTime PeditedDate, Address address)
        {
            this.cin.Value = cin;
            this.firstName.Value = firstName;
            this.lastName.Value = lastName;
            this.phonenumber.Value = phonenumber;
            this.PeditedDate.Value = PeditedDate;
            this.address.Value = address;
        }

        public Person(
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
            UserStatus status):base(id, email, password, salt, createdDate, editedDate, role, status)
        {
            this.cin.Value = cin;
            this.firstName.Value = firstName;
            this.lastName.Value = lastName;
            this.phonenumber.Value = phoneNumber;
            this.PeditedDate.Value = PeditedDate;
            this.address.Value = address;
        }


    }
}