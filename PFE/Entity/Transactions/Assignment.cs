using System;
using PFE.Entity.HumanRessources;
using PFE.Tiers.Data_Access_Layer;
namespace PFE.Entity.Transactions
{
    public class Assignment
    {
        public Data id = new Data("assignment_id");
        public Data assignmentDate = new Data("assignment_date");
        public Data editedDate = new Data("edited_date");
        public Data order = new Data("order_id");
        public Data employee = new Data("employer_id");
        public Data driver = new Data("driver_id");
        public Data assignmentType = new Data("assignment_type");
        public Data done = new Data("done");

        public Assignment() { }
        public Assignment(int id) { this.id.Value = id; }
        public Assignment(int id, DateTime assignmentDate, DateTime editedDate,OrderTransport order,Employee employee,Driver driver,String assignmentType,bool done)
        {
            this.id.Value = id;
            this.assignmentDate.Value = assignmentDate;
            this.editedDate.Value = editedDate;
            this.order.Value = order;
            this.employee.Value = employee;
            this.driver.Value = driver;
            this.assignmentType.Value = assignmentType;
            this.done.Value = done;
        }
    }
}