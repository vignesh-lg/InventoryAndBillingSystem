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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Registration")]
        public ActionResult Registration_Post()
        {
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {

            }
            else
            {
                Message = "Invalid Required";

            }
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
                return RedirectToAction("ShowCollege", "College");
            }
            TempData["Message"] = "Incorrect EmailId or Password";
            return View();
        }
    }
}