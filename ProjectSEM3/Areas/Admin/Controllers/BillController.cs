using ProjectSEM3.DAL.Models.Entity;
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
            return View();
        }
        
    }
}