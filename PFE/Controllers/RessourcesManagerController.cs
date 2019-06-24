using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PFE.Entity.Authentification;
using PFE.Entity.HumanRessources;
using PFE.Entity.Transactions;
using System.Web.Mvc;
using PFE.Tiers.simple_Authentification_Security_Layer;
using PFE.Tiers.Buisnes_Objects_Layer;

namespace PFE.Controllers
{
    public class RessourcesManagerController : Controller
    {
        private BuisnesObject bo = new BuisnesObject();
        private AuthentificationEncryption ae = new AuthentificationEncryption();




        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["RessourcesManager"] == null)
                filterContext.HttpContext.Response.RedirectToRoute("");
        }




        // GET: RessourcesManager
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Assignments()
        {
            Assignment assignment = new Assignment();
            assignment.done.Value = false;
            List<Assignment> listUncheckedAssigments = bo.FilteringBy(assignment.done).getAssignments();

            return View(listUncheckedAssigments);
        }

        public ActionResult SuccesfullAssignment(int? id)
        {
            int ids = 0;
            ids = (int)id;
            Assignment assignment = new Assignment(ids);

            assignment.done.Value = true;
            String msg = "fail";
            if (bo.AssignmentSuccess(assignment) != -1)
                msg = "success";
            return RedirectToAction("Assignments", "RessourcesManager");
        }

        public ActionResult Drivers()
        {
            List<Driver> drivers = bo.getDriver();
            return View(drivers);
        }

        public ActionResult SwitchAvailability(int? id)
        {
            int ids = 0;
            ids = (int)id;

            Driver driver = new Driver(ids);
            driver = bo.FilteringBy(driver.dvrId).getDriver()[0];

            if ((bool)driver.available.Value)
                driver.available.Value = false;
            else
                driver.available.Value = true;
            if (bo.SwitchAvailability(driver) == -1)
                return Content("fail");
            return RedirectToAction("Drivers", "RessourcesManager");
        }

        public ActionResult Details(int? id)
        {
            int ids = 0;
            ids =5;
            List<Assignment> DriverAssignments = bo.getDriverAssignments(new Driver(ids).dvrId);

            return View(DriverAssignments);
        }
        
        public ActionResult logout()
        {
            User user = new User((int)Session["RessourcesManager"]);
            bo.loggedIn(bo.FilteringBy(user.id).getUser()[0], false);
            Session["RessourcesManager"] = null;
            return RedirectToAction("Index", "HomePage");
        }

    
    }
}