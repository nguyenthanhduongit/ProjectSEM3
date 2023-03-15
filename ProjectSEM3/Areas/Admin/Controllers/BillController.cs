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
        public ActionResult Index(SearchBillDTO param, int page = 1)
        {
            int pageSize = 5;
            var data = dbcontext.Bills.ToList();
            var products = dbcontext.Products.ToList();
            var customers = dbcontext.Customers.ToList();   
            var join = from pro in products
                       join b in data
                       on pro.Id equals b.ProductId
                       /* into gr1
                        from b in gr1.DefaultIfEmpty()*/
                       join cus in customers
                       on b.CustomerId equals cus.Id
                       /*into gr from cus in gr.DefaultIfEmpty()*/
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
                           TotalPrice = /*b.TotalPrice == null ? default :*/ 0,
                           CustomerName =  cus.Name,
                           Phone = cus.Phone,
                       };
            var list = join.Where(x => x.Status == StatusCart.StatusBill).ToList();
           
            for (int i = 0; i < list.Count(); i++)
            {
                list[i].TotalPrice = list[i].Price * list[i].Quantity;
            }
            if (!String.IsNullOrEmpty(param.ProductName))
            {
                list = list.Where(x => x.ProductName.Trim().ToLower().Contains(param.ProductName.Trim().ToLower()) || x.CustomerName.Trim().ToLower().Contains(param.ProductName.Trim().ToLower())).ToList();
            }
            ViewBag.totalPage = Math.Ceiling((decimal)list.Count() / (decimal)pageSize);
            return View(list.Skip((page - 1) * pageSize).Take(pageSize));
            //return View(list);
        }
        
    }
}