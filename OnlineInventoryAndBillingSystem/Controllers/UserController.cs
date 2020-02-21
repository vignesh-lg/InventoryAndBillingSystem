using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineInventoryAndBillingSystem.BL;
using OnlineInventoryAndBillingSystem.Entity;

namespace OnlineInventoryAndBillingSystem.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager;
        public UserController()
        {
            userManager = new UserManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Registration")]
        public ActionResult Registration_Get()
        {
            ViewBag.Roles = new SelectList(UserManager.GetDetails());
            //if (ViewBag.Roles.Text == "Tamil Nadu")
            //{
            //    ViewBag.City = new SelectList(UserManager.GetTamilNaduDetails());
            //}
            //else if (ViewBag.Roles.Text == "Andhra Pradesh")
            //{
            //    ViewBag.City = new SelectList(UserManager.GetAndhraDetails());
            //}
            //else if (ViewBag.Roles.Text == "Bangalore")
            //{
                ViewBag.City = new SelectList(UserManager.GetBangloreDetails());
            //}
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Registration")]
        public ActionResult Registration_Post()
        {
            ViewBag.Roles = new SelectList(UserManager.GetDetails());
           
            //if (ViewBag.Roles.Text == "Tamil Nadu")
            //{
            //    ViewBag.City = new SelectList(UserManager.GetTamilNaduDetails());
            //}
            //else if (ViewBag.Roles.Text == "Andhra Pradesh")
            //{
            //    ViewBag.City = new SelectList(UserManager.GetAndhraDetails());
            //}
            //else if (ViewBag.Roles.Text == "Bangalore")
            //{
           // ViewBag.City = new SelectList(UserManager.GetBangloreDetails());
            //}
            User user = new User();
            TryUpdateModel(user);
            userManager.GetCustomerDetails(user);
            TempData["Message"] = "Registered Sucessfully";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            User user = new User(Request.Form["emailId"], Request.Form["password"]);
            if (userManager.ToLogin(user) == true)
            {
                return RedirectToAction("Page", "User");
            }
            TempData["Message"] = "Incorrect UserName or Password";
            return View();
        }
        public ActionResult Menu()
        {
            return PartialView("Menu");
        }
        //[NonAction]
        public ActionResult Page()
        {
            return View();
        }
        
        public ActionResult EmptyPage()
        {
            return PartialView("EmptyPage");
        }
    }
}