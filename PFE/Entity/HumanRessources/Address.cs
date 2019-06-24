using System;
using PFE.Tiers.Data_Access_Layer;
namespace PFE.Entity.HumanRessources
{
    public class Address
    {
        public Data id = new Data("address_id");
        public Data state = new Data("state");
        public Data city = new Data("city");
        public Data addressLine1 = new Data("address_line_1");
        public Data addressLine2 = new Data("address_line_2");
        public Data zipCode = new Data("zip_code");
        public Data editDate = new Data("edited_date");


        public Address() { }
        public Address(int id) { this.id.Value = id; }
        public Address(int id,String state,String city,String addressLine1,String addressLine2,int zipCode,DateTime editDate)
        {
            this.id.Value = id;
            this.state.Value = state;
            this.city.Value = city;
            this.addressLine1.Value = addressLine1;
            this.addressLine2.Value = addressLine2;
            this.zipCode.Value = zipCode;
            this.editDate.Value = editDate;
        }

    }
}