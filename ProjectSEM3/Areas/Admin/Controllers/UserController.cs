using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DLL.IRepository;
using ProjectSEM3.DLL.Repository;
using System.Web.Mvc;

namespace ProjectSEM3.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        private static IUser userservice;
        public UserController()
        {
            userservice = new UserService();
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
        
    }
}