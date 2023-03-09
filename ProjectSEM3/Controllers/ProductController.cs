using ProjectSEM3.DAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSEM3.Controllers
{
    public class ProductController : Controller
    {
        private static Migrations dbcontext;
        public ProductController()
        {
            dbcontext = new Migrations();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(Guid id)
        {
          var data =  dbcontext.Products.Find(id);

            return View(data);
        }
        
        [HttpPost]
        public ActionResult AddCart(Bill bill)
        {
            var username = Response.Cookies["UserName"].Value;
            var customers = dbcontext.Customers.FirstOrDefault(x => x.UserName == username);
            bill.CustomerId = customers.Id;
            dbcontext.Bills.Add(bill);
            dbcontext.SaveChanges();
            return RedirectToAction("Thêm thành công");
            
        }
    }
}