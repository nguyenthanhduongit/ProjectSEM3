using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DAL.Models.Enum.EnumCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSEM3.Controllers
{
    public  class HomeController : Controller
    {
        private static Migrations dbcontext;
        public  HomeController()
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
        public ActionResult Login(string Username , string Password)
        {
            if(ModelState.IsValid)
            {
               var query = dbcontext.Customers.FirstOrDefault(x => x.UserName.Trim().ToLower().Contains(Username.Trim().ToLower()));
                if (query == null) return View();
                if (query.Password == Password) {
                    Session["UserName"] = Username;
                    return RedirectToAction("Index");
                } 

            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = Guid.NewGuid();
                dbcontext.Customers.Add(customer);
                dbcontext.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
        public static List<Banned>  GetlistBanned()
        {
          var data =  dbcontext.Banneds.ToList();
            return data;
        }
        public static List<Product> GetListProduct()
        {
            var data = dbcontext.Products.ToList();
            return data;
        }
        public static List<Product> GetStatusProductNew()
        {
            var data = dbcontext.Products;
            var list = data.Where(x => x.StatusProduct == StatusProduct.ProductNew).Take(3).ToList();
            return list;
        }
        public static List<Product> GetStatusProductRecently()
        {
            var data = dbcontext.Products.ToList();
            var list = data.Where(x => x.StatusProduct == StatusProduct.ProductRecently).Take(3).ToList();
            return list;
        }
        public static List<Product> GetStatusProductSeller()
        {
            var data = dbcontext.Products.ToList();
            var list = data.Where(x => x.StatusProduct == StatusProduct.ProductSeller).Take(3).ToList();
            return list;
        }
    }
}