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
    public class BannedController : Controller
    {
        private static IBanned bannedService;
        public BannedController()
        {
            bannedService = new BannedService();
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
    }
}