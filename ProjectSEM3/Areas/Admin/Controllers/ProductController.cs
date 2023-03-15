using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DLL.IRepository;
using ProjectSEM3.DLL.Repository;
using ProjectSEM3.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public ActionResult Index(SearchProductDTO param, int page = 1)
        {
            int pageSize = 5;
            var data = dbcontext.Products.AsEnumerable();
            if (!String.IsNullOrEmpty(param.Name))
            {
                data = data.Where(x => x.Name.Trim().ToLower().Contains(param.Name.Trim().ToLower()) || x.Description.Trim().ToLower().Contains(param.Name.Trim().ToLower()));
            }
            ViewBag.totalPage = Math.Ceiling((decimal)data.Count() / (decimal)pageSize);
            return View(data.Skip((page - 1) * pageSize).Take(pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(HttpPostedFileBase Images, Product product)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    product.Images = Images.FileName;
                    product.Id = Guid.NewGuid();

                    var data = dbcontext.Products.Add(product);
                    dbcontext.SaveChanges();
                    if (Images != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Areas/Uploand"), Path.GetFileName(Images.FileName));
                        Images.SaveAs(path);

                    }

                    if (data != null)
                    {

                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception e)
            {

                ViewBag.FileStatus = e.Message;
            }



            return View();
        }
        public ActionResult Delete(Guid id)
        {
            var data = dbcontext.Products.Find(id);
            dbcontext.Products.Remove(data);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(Guid id)
        {
            var data = dbcontext.Products.Find(id);

            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(HttpPostedFileBase Images, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.Images = Images.FileName;

                    if (Images != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Areas/Uploand"), Path.GetFileName(Images.FileName));
                        Images.SaveAs(path);

                    }

                    dbcontext.Products.AddOrUpdate(product);
                    dbcontext.SaveChanges();
                    return RedirectToAction("Index");

                }

            }
            catch (Exception e)
            {

                ViewBag.FileStatus = e.Message;
            }
            return View();
        }
    }
}