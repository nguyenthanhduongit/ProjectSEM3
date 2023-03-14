using ProjectSEM3.DAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSEM3.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private static Migrations dbcontext;
        public CustomerController()
        {
            dbcontext = new Migrations();
        }
        // GET: Admin/Customer
        public ActionResult Index()
        {
            var data = dbcontext.Customers.ToList();
            return View(data);
        }
        public ActionResult Delete(Guid id)
        {
            var data = dbcontext.Customers.Find(id);
            dbcontext.Customers.Remove(data);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}