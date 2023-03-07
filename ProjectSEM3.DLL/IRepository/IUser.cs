using ProjectSEM3.DAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DLL.IRepository
{
    public interface IUser
    {
        List<User> GetList();
        bool Create(User user);
    }
}
