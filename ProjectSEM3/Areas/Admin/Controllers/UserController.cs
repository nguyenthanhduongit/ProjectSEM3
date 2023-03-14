using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DLL.IRepository;
using ProjectSEM3.DLL.Repository;
using System;
using System.Data.Entity.Migrations;
using System.Web.Mvc;

namespace ProjectSEM3.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        private static IUser userservice;
        private static Migrations dbcotext;

        public UserController()
        {
            userservice = new UserService();
            dbcotext = new Migrations();
        }
        public ActionResult Index()
        {
            var list = userservice.GetList();
           return View(list);
        }
        
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(User user) {
            if (ModelState.IsValid)
            {
                var data = userservice.Create(user);
                if (data == true)
                {
                    return RedirectToAction("Index");
                }
            }
          
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            var data = dbcotext.Users.Find(id);
            dbcotext.Users.Remove(data);
            dbcotext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Guid id)
        {
            var data = dbcotext.Users.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(User user) {
            if (ModelState.IsValid)
            {
                dbcotext.Users.AddOrUpdate(user);
                dbcotext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}