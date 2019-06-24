using System;
using System.Web.Mvc;
using PFE.Entity.Authentification;
using PFE.Entity.HumanRessources;
using PFE.Tiers.simple_Authentification_Security_Layer;
using PFE.Tiers.Buisnes_Objects_Layer;
namespace PFE.Controllers
{
    public class HomePageController : Controller
    {
        private AuthentificationEncryption ae =new AuthentificationEncryption();
        private BuisnesObject bo = new BuisnesObject();


        

        public ViewResult Join()
        {
            return View();
        }



        [Route("")]
        public ViewResult Index()
        {
            return View();
        }
        

        public ActionResult Authentificated(String email,String password)
        {
            String errors="";
            if (!ae.authentificateUser(new User(email, password, ""), ref errors))
            {
                TempData["error"] = errors;
                return RedirectToAction("Join", "HomePage");
            }
            User user = new User(email);
            user = bo.FilteringBy(user.email).getUser()[0];

            bo.loggedIn(user, true);
            UserRole role =(UserRole) user.role.Value;
            role = bo.FilteringBy(role.id).getRole()[0];
                Session[(String)role.role.Value] = user.id.Value;
                return RedirectToAction("Index", (String)role.role.Value);
        }
        
        public ActionResult addCustomer(
            String email,
            String password,
            int? cin,
            String firstName,
            String lastName,
            int? phoneNumber,
            String job,
            String state,
            String city,
            String addressLine1,
            String addressLine2,
            int? zipcode
            )
        {
            
            try
            {
                if (bo.FilteringBy(new User(email).email).getUser()[0].id.Value != null)
                    TempData["errorSign"] = "Email Already Exist";
            }
            catch (Exception){}
            int address = bo.addAddress(new Address(0, state, city, addressLine1, addressLine2,(int) zipcode,new DateTime()));
            int customerid = ae.addSecuredCustomer(new Customer(
                0,
                job,
                DateTime.Now,
                (int)cin,
                firstName,
                lastName, 
                (int)phoneNumber,
                DateTime.Now,
                new Address(address),
                0,
                email,
                password,
                null,
                DateTime.Now,
                DateTime.Now,
                new UserRole(1),
                new UserStatus()));
            
            return RedirectToAction("Join", "HomePage");
        }

        
    }
}