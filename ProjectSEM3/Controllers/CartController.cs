using ProjectSEM3.DAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSEM3.Controllers
{
    public class CartController : Controller
    {
        private static 
        public CartController()
        {
            
        }
        // GET: Cart
        public ActionResult Index()
        {
           
        }
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            var section = Session["Customer"] = customer;
           
        }
        public ActionResult ListCart()
        {
           

        }
    }
}