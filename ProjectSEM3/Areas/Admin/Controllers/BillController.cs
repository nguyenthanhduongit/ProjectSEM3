using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DAL.Models.Enum.EnumCart;
using ProjectSEM3.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSEM3.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        private static Migrations dbcontext;
        public BillController()
        {
            dbcontext = new Migrations();
        }
        // GET: Admin/Bill
        public ActionResult Index()
        {
           var data = dbcontext.Bills.ToList();
            var products = dbcontext.Products.ToList();
            var join = from pro in products
                       join b in data
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
            
            for (int i = 0; i < lst.Count(); i++)
            {
                lst[i].TotalPrice = lst[i].Price * lst[i].Quantity;
            }
            var list = join.Where(x => x.Status == StatusCart.StatusCart).ToList();
            return View(list);
        }
        
    }
}