using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DLL.IRepository;
using ProjectSEM3.DLL.Repository;
using ProjectSEM3.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
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
        public ActionResult Index(SearchProductDTO param, int page = 1)
        {
            int pagesize = 1;
          var data =  dbcontext.Products.AsEnumerable();
            if (!String.IsNullOrEmpty(param.Name))
            {
                data = data.Where(x => x.Name.Trim().ToLower().Contains(param.Name.Trim().ToLower()));
            }
            ViewBag.totalPage = Math.Ceiling((decimal)data.Count() / (decimal)pagesize);
          
            return View(data.Skip((page - 1) * pagesize).Take(pagesize).ToList());
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