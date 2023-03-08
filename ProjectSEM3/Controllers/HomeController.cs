using ProjectSEM3.DAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSEM3.Controllers
{
    public class HomeController : Controller
    {
        private static Migrations dbcontext;
        public HomeController()
        {
            dbcontext = new Migrations();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username , string password)
        {
            if(ModelState.IsValid)
            {
               var query = dbcontext.Customers.FirstOrDefault(x => x.UserName.Trim().ToLower().Contains(Username.Trim().ToLower()));
                if (query == null) return View();
                if (query.password == password) return View("index");

            }
            return View();
        }
    }
}