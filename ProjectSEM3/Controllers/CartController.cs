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
    public class CartController : Controller
    {
        private static Migrations dbcontext;
        public CartController()
        {
            dbcontext = new Migrations();
        }
        // GET: Cart
        public ActionResult Index()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            var section = Session["Customer"] = customer;
            return View();
           
        }
        public ActionResult ListCart()
        {
            var username = Response.Cookies["UserName"].Value;
            var customers = dbcontext.Customers.FirstOrDefault(x => x.UserName == username);
            
            var query = from b in dbcontext.Bills
                        join pro in dbcontext.Products
                        on b.ProductId equals pro.Id
                        select new ListCartDTO
                        {
                            Id = b.Id,
                            Created = b.Created,
                            CustomerId = b.CustomerId,
                            ProductId = pro.Id,
                            ProductName = pro.Name,
                            Quantity = b.Quantity,
                            Status = b.Status,

                            TotalPrice = b.TotalPrice
                        };
            var data = query.Where(x => x.CustomerId == customers.Id && x.Created == DateTime.Now.Date);
            var list = data.Where(x=> x.Status == StatusCart.StatusCart).ToList();    
            return View(list);

        }
        public  ActionResult UpdateStatusCart(List<Guid> id)
        {

           var query = dbcontext.Bills.Where(x => id.Contains(x.Id));
            // to muon update cai list nay 
            var data = from b in query
                       select new Bill
                       {
                           Created = b.Created,
                           CustomerId = b.CustomerId,
                           Id = b.Id,
                           ProductId = b.Id,
                           Quantity = b.Quantity,
                           TotalPrice = b.TotalPrice,
                           Status = StatusCart.StatusBill
                       };
           
          
                dbcontext.Entry(data).State = EntityState.Modified; 
                dbcontext.SaveChanges();
          
           
            
            return View();
        }
    }
}