using ProjectSEM3.DAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProjectSEM3.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private static Migrations dbcontext;
        public HomeController()
        {
            dbcontext = new Migrations();
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string Password) {
            if (ModelState.IsValid)
            {
                var query = dbcontext.Users.FirstOrDefault(x => x.Name.Trim().ToLower().Contains(UserName.Trim().ToLower()));
                if (query == null) return View();
                if (query.Password == Password)
                {
                    Session["UserNameAdmin"] = UserName;
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("UserNameAdmin");
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                
                dbcontext.Users.Add(user);
                dbcontext.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();  
           
        }
    }
}