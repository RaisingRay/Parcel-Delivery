using System;
using PFE.Entity.Authentification;
using PFE.Tiers.Data_Access_Layer;

namespace PFE.Entity.HumanRessources
{
    public class Employee:Person
    {
        public Data empId = new Data("employer_id");
        public Data title = new Data("title");
        public Data hireDate = new Data("hire_date");
        public Data empEditedDate = new Data("edited");


        public Employee() { }
        public Employee(int empId) { this.empId.Value = empId; }
        public Employee(int empId,String title,DateTime hireDate,DateTime empEditedDate)
        {
            this.empId.Value = empId;
            this.title.Value = title;
            this.hireDate.Value = hireDate;
            this.empEditedDate.Value = empEditedDate;
        }

        public Employee(
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
            UserStatus status) : base(cin,firstName,lastName, phoneNumber, PeditedDate,address, id, email, password, salt, createdDate, editedDate, role, status)
        {
            this.empId.Value = empId;
            this.title.Value = title;
            this.hireDate.Value = hireDate;
            this.empEditedDate.Value = empEditedDate;
        }
    }
}