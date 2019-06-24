using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PFE.Tiers.Data_Access_Layer;
namespace PFE.Entity.Transactions
{
    public class Invoice
    {
        public Data id = new Data("invoice_id");
        public Data price = new Data("price");
        public Data RecommandationTax = new Data("recommendation_tax");
        public Data AcknowledgmentOfReceipt = new Data("acknowledgment_of_receipt");
        public Data RemainingPostTax = new Data("remaining_post_tax");


        public Invoice() { }

        public Invoice(int id)
        {
            this.id.Value = id;
        }

        public Invoice(int id,double price, bool RecommandationTax,bool AcknowledgmentOfReceipt, bool RemainingPostTax)
        {
            this.id.Value = id;
            this.price.Value = price;
            this.RecommandationTax.Value = RecommandationTax;
            this.AcknowledgmentOfReceipt.Value = AcknowledgmentOfReceipt;
            this.RemainingPostTax.Value = RemainingPostTax;
        }
    }
}