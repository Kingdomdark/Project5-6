using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Ticketshop.Controllers;
using Model;
using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.Session;
using Ticketshop.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ticketshop.Controllers
{
    public class AccountController : Controller
    {
        // Get : Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer account)
        {
            if (ModelState.IsValid)
            {
                using (TicketContext db = new TicketContext())
                {
                    db.Customers.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Username + " " + account.Userlastname + "succesfully registerd.";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            using (TicketContext db = new TicketContext())
            {
                var user = db.Customers.Where(u => u.Username == customer.Username && u._password == customer._password).FirstOrDefault();
                if (user != null)
                {
                    Session["UserID"] = customer.UserID.ToString();
                    Session["Username"] = customer.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password do not match.");
                }
            }
            return View();
        }
        
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}