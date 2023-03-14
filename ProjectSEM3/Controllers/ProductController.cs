using Microsoft.Ajax.Utilities;
using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DAL.Models.Enum.EnumCart;
using ProjectSEM3.Dto;
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
          var list =  dbcontext.Products.ToList();
            return View(list);
        }
        public ActionResult Detail(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
          var data =  dbcontext.Products.Find(id);

            return View(data);
        }
        
        [HttpPost]
        public ActionResult AddCart(Guid id, int quantity)
        {
            Bill bill = new Bill();
            var user = Session["UserName"];
            if (user == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home" });
            }
            var username = user.ToString();
            var customers = dbcontext.Customers.FirstOrDefault(x => x.UserName.ToLower().Trim() == username.ToLower().Trim());
            var product = dbcontext.Products.Find(id);
            bill.CustomerId = customers.Id;
            bill.ProductId = id;
            bill.Created = DateTime.Now;
            bill.Status = StatusCart.StatusCart;
            bill.Id = Guid.NewGuid();
            bill.Quantity = quantity;
            dbcontext.Bills.Add(bill);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }
        public static List<Product> GetListProductInDetail()
        {
            var data = dbcontext.Products.Take(4).ToList();
            
            return data;
           
        }
    }
}