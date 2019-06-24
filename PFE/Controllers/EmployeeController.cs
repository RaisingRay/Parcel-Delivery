using PFE.Entity.Authentification;
using PFE.Entity.HumanRessources;
using PFE.Entity.Transactions;
using PFE.Tiers.Buisnes_Objects_Layer;
using PFE.Tiers.simple_Authentification_Security_Layer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace PFE.Controllers
{
    public class EmployeeController : Controller
    {
        private BuisnesObject bo = new BuisnesObject();
        private AuthentificationEncryption ae = new AuthentificationEncryption();


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Employee"] == null)
                filterContext.HttpContext.Response.RedirectToRoute("");
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeliveryAssignment()
        {
            OrderTransport order = new OrderTransport();
            List<OrderTransport> deliverys = bo.getDeliveryOrder();
            return View(deliverys);
        }

        public ActionResult PickupAssignments()
        {
            OrderTransport order = new OrderTransport();
            List<OrderTransport> deliverys = bo.getPickupOrder();
            return View(deliverys);
        }
        

        public ActionResult PickupDetails(int? id)
        {
            int ids =0;
            ids = (int)id;
            OrderTransport order = bo.FilteringBy(new OrderTransport(ids).id).getOrderTransport()[0];
            return View(order);
        }

        public ActionResult DeliveryDetails(int? id)
        {
            int ids = 0;
            ids = (int)id;

            OrderTransport order = bo.FilteringBy(new OrderTransport(ids).id).getOrderTransport()[0];
            return View(order);
        }

        public ActionResult availableDriverDelivery(int? id)
        {
            int ids = 0;
            ids = (int)id;
            OrderTransport order = new OrderTransport(ids);
            return View(order);
        }

        public ActionResult AvailableDrivers(int? id)
        {
            int ids = 0;
            ids = (int)id;
            OrderTransport order = new OrderTransport(ids);
            return View(order);
        }
        
        public ActionResult AssignDriverPickup(int ?id1,int ? id2)
        {
            int orderid = 0;
            int driverid = 0;
            orderid = (int)id1;
            driverid = (int)id2;
            Employee employee = new Employee();
            employee.id.Value = Session["Employee"];
            employee = bo.FilteringBy(employee.id).getEmployee()[0];

            int id=bo.addAssignment(new Assignment(0, DateTime.Now, DateTime.Now, new OrderTransport(orderid),employee, new Driver(driverid),"pickup",false));
            return RedirectToAction("PickupAssignments", "Employee");
        }


        public ActionResult AssignDriverDelivery(int? id1, int? id2)
        {
            int orderid = 0;
            int driverid = 0;
            orderid = (int)id1;
            driverid = (int)id2;
            Employee employee = new Employee();
            employee.id.Value = Session["Employee"];
            employee = bo.FilteringBy(employee.id).getEmployee()[0];

            int id = bo.addAssignment(new Assignment(0, DateTime.Now, DateTime.Now, new OrderTransport(orderid), employee, new Driver(driverid), "delivery", false));
            return RedirectToAction("DeliveryAssignment", "Employee");
        }


        public ActionResult logout()
        {
            Session["Employee"] = null;
            return RedirectToAction("Index", "HomePage");
        }
    }
}