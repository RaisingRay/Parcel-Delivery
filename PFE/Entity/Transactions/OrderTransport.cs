using System;
using PFE.Entity.HumanRessources;
using PFE.Tiers.Data_Access_Layer;
namespace PFE.Entity.Transactions
{
    public class OrderTransport
    {
        public Data id = new Data("order_id");
        public Data createdDate = new Data("created_date");
        public Data pickupLocation = new Data("pickup_location");
        public Data destination = new Data("destination");
        public Data package = new Data("package_id");
        public Data customer = new Data("customer_id");
        public Data invoice = new Data("Invoice_id");

        public OrderTransport() { }
        public OrderTransport(int id) { this.id.Value = id; }
        public OrderTransport(int id,DateTime createdDate,Location pickupLocation,Location destination,Package package,Customer customer,Invoice invoice)
        {
            this.id.Value = id;
            this.createdDate.Value = createdDate;
            this.pickupLocation.Value = pickupLocation;
            this.destination.Value = destination;
            this.package.Value = package;
            this.customer.Value = customer;
            this.invoice.Value = invoice;
        }
    }
}