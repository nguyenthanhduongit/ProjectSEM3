using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DAL.Models.Enum.EnumCart;
using ProjectSEM3.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
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
        
     
       // danh sach Cart
        public ActionResult ListCart()
       {
            var user = Session["UserName"];
            if (user == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home" });
            }
            var username = user.ToString();
            var products = dbcontext.Products.ToList();
            var bills = dbcontext.Bills.ToList();
            var customers = dbcontext.Customers.FirstOrDefault(x => x.UserName == username);

            var join = from pro in products
                        join b in bills
                        on pro.Id equals b.ProductId
                        /*into gr from b in gr.DefaultIfEmpty()*/
                        select new ListCartDTO
                        {
                            Id = /*b.Id == null ? default :*/ b.Id,
                            Created = /*b.Created == null ? default :*/ b.Created,
                            CustomerId = /*b.CustomerId == null ? default :*/ b.CustomerId,
                            ProductId = pro.Id,
                            ProductName = pro.Name,
                            Price = pro.price,
                            Quantity = /*b.Quantity == null ? default :*/b.Quantity,
                            Status = b.Status /*== null ? StatusCart.StatusCart : StatusCart.StatusBill*/,
                            Images = pro.Images,
                            TotalPrice = /*b.TotalPrice == null ? default :*/ b.TotalPrice,
                        };
            var lst = join.ToList();
            double totalprice = 0;
            for (int i = 0; i < lst.Count(); i++)
            {
                lst[i].TotalPrice = lst[i].Price * lst[i].Quantity;
            }

            var data = lst.Where(x => x.CustomerId == customers.Id);
            /*data = data.Where(x => x.Created.Date == DateTime.Now.Date);*/
            
            var list = data.Where(x=> x.Status == StatusCart.StatusCart).ToList();    
            return View(list);

        }

        // update Cart qua Bill ADMIN
        [HttpPost]
        public  ActionResult UpdateStatusCart(List<Guid> id)
        {

           var query = dbcontext.Bills.Where(x => id.Contains(x.Id)).ToList();
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
           var list = data.ToList();
            foreach (var item in list)
            {
                dbcontext.Bills.AddOrUpdate(item);
                
            }
            dbcontext.SaveChanges();
            return RedirectToAction("ListCart");
        }
        
        public ActionResult Delete(Guid id)
        {
            var data = dbcontext.Bills.Find(id);
            dbcontext.Bills.Remove(data);
            dbcontext.SaveChanges();
            return RedirectToAction("ListCart");
        }
        [HttpPost]
        public ActionResult UpdateQuantity(Guid id, int quantity)
        {
           var bill = dbcontext.Bills.Find(id);
            bill.Quantity = quantity;
            
            dbcontext.Bills.AddOrUpdate(bill);
            dbcontext.SaveChanges();
            return RedirectToAction("ListCart");
        }
    }
}