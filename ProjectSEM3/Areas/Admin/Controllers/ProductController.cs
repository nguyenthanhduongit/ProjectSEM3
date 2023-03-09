using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DLL.IRepository;
using ProjectSEM3.DLL.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSEM3.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private static Migrations dbcontext;
        public ProductController()
        {
            dbcontext = new Migrations();
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase Images,Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    product.Images = Images.FileName;
                    product.Id = Guid.NewGuid();
                    var data = dbcontext.Products.Add(product);

                    if (Images != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Areas/Uploand"), Path.GetFileName(Images.FileName));
                        Images.SaveAs(path);

                    }


                    if (data != null)
                    {
                        return View("Index");
                    }

                }
                catch (Exception e)
                {

                    ViewBag.FileStatus = e.Message;
                }


            }
            return View();
        }
    }
}