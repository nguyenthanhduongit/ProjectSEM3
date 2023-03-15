using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.Dto;
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
        public ActionResult Index(SearchCustomerDTO param, int page = 1)
        {
            int pageSize = 5;
            var data = dbcontext.Customers.AsEnumerable();
            if (!String.IsNullOrEmpty(param.Name))
            {
                data = data.Where(x => x.Name.Trim().ToLower().Contains(param.Name.Trim().ToLower()));
            }
            ViewBag.totalPage = Math.Ceiling((decimal)data.Count() / (decimal)pageSize);
            return View(data.Skip((page - 1) * pageSize).Take(pageSize));
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