using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PFE.Entity.Authentification;
using PFE.Entity.Transactions;
using PFE.Entity.HumanRessources;
using PFE.Tiers.Buisnes_Objects_Layer;
namespace PFE.Controllers
{
    public class CustomerController : Controller
    {
        private BuisnesObject bo = new BuisnesObject();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Customer"] == null)
                filterContext.HttpContext.Response.RedirectToRoute("");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MakeDelevery()
        {
            return View();
        }


        public ActionResult DeliveryHistory()
        {
            OrderTransport order = new OrderTransport();
            List<OrderTransport> listDeliverys = new List<OrderTransport>();
            try
            {
                order.customer.Value = bo.FilteringBy(new User((int)Session["Customer"]).id).getCustomer()[0];
                listDeliverys = bo.FilteringBy(order.customer).getOrderTransport();
            }
            catch (Exception) { }
                
           

            return View(listDeliverys);
        }

        
        public ActionResult test(
            float Weight,
            String MatterialType,
            String pstate,
            String pcity,
            String paddress,
            int pzipCode, 
            String dstate,
            String dcity,
            String daddress,
            int dzipCode,
            double pllng,
            double pllat,
            double dllng,
            double dllat,
            int number,
            int cvv,
            String name,
            bool Recommendation=false,
            bool AcknowledgmentOfReceipt = false,
            bool RemainingPost = false
            )
        {


            if (bo.checkCard(number, cvv, name) == false)
                return Content("card doesn't exist");
            else
            {
                //price of delivery
                double price = 4.300;
                if (Weight > 2000)
                    price = 0.3 * Math.Ceiling(1000 / (Weight - 2000));
                if (Recommendation)
                    price += 2;
                if (AcknowledgmentOfReceipt)
                    price += 2.4;
                if (RemainingPost)
                    price += 0.5;

                //setting our entity
                Invoice invoice = new Invoice(0, price, Recommendation, AcknowledgmentOfReceipt, RemainingPost);
                String errors = "";
                Package package = new Package(0, MatterialType, Weight);
                Location pickup = new Location(0, pstate, pcity, paddress, pzipCode, pllat, pllng);
                Location destination = new Location(0, dstate, dcity, daddress, dzipCode, dllat, dllng);
                




                //add entity + check for errors
                int packageid = bo.addPackage(package);
                int pickupid = bo.addLocation(pickup);
                int destinationidbo = bo.addLocation(destination);
                int invoiceid = bo.addInvoice(invoice);
                if (packageid == -1)
                    errors += "package error ";
                if (pickupid == -1)
                    errors += "pickup error ";
                if (destinationidbo == -1)
                    errors += "destination error ";
                if (invoiceid == -1)
                    errors += "invoice error";

                int deliveryid = bo.addOrderTransport(new OrderTransport(0,
                    DateTime.Now,
                    new Location(pickupid),
                    new Location(destinationidbo),
                    new Package(packageid),
                    bo.FilteringBy(new User((int)Session["Customer"]).id).getCustomer()[0], new Invoice(invoiceid)));
                if (deliveryid == -1)
                    errors += "delevrery erro";

                return RedirectToAction("MakeDelevery", "Customer");
            }

        }
        

        public ViewResult about()
        {
            return View();
        }
        public ViewResult contact()
        {
            return View();
        }
        public ViewResult guide()
        {
            return View();
        }

        public ActionResult logout()
        {
            User user = new User((int)Session["Customer"]);
            bo.loggedIn(bo.FilteringBy(user.id).getUser()[0], false);
            Session["Customer"] = null;
            return RedirectToAction("Index", "HomePage");
        }
    }
}