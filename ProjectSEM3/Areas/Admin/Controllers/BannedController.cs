using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DLL.IRepository;
using ProjectSEM3.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSEM3.Areas.Admin.Controllers
{
    public class BannedController : Controller
    {
        private static IBanned bannedService;
        private static Migrations dbcontext;

        public BannedController()
        {
            bannedService = new BannedService();
            dbcontext = new Migrations();
        }
        // GET: Admin/Banned
        public ActionResult Index()
        {
            var list = bannedService.Getlist();
            return View(list);
        }
        public ActionResult Create() {
            return View();
        }
      
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase Images, Banned banned) {
            
            if (ModelState.IsValid)
            {
                try
                {

                    banned.Images = Images.FileName;
                    banned.Id = Guid.NewGuid();
                    var data = bannedService.Create(banned);
                   
                    if (Images != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Areas/Uploand"), Path.GetFileName(Images.FileName));
                        Images.SaveAs(path);

                    }
                   
             
                    if (data == true)
                    {
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception e)
                {

                    ViewBag.FileStatus = e.Message;
                }
               
                
            }
            return View();

        }
        
        public ActionResult Delete(Guid id)
        {
            var data = dbcontext.Banneds.Find(id);
            dbcontext.Banneds.Remove(data);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(Guid id)
        {
            var data = dbcontext.Banneds.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(HttpPostedFileBase Images, Banned Banned)
        {
            if (ModelState.IsValid)
            {
                Banned.Images = Images.FileName;
                
                

                if (Images != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Areas/Uploand"), Path.GetFileName(Images.FileName));
                    Images.SaveAs(path);

                }
                dbcontext.Banneds.AddOrUpdate(Banned);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}