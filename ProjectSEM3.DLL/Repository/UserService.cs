using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DLL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DLL.Repository
{
    public class UserService : IUser
    {
        private static  Migrations dbcontext;

        

        public UserService()
        {
            dbcontext = new Migrations();
        }
        public List<User> GetList()
        {
            return dbcontext.Users.ToList();
        }
        public bool Create(User user)
        {
            if (user == null) { 
            return false;
            }
            user.Id = Guid.NewGuid();
            var data = dbcontext.Users.Add(user);
            dbcontext.SaveChanges();
            if (data != null)
            {
                return true;
            }
            return false;

        }
    }
}
