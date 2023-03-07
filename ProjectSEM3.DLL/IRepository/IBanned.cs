using ProjectSEM3.DAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DLL.IRepository
{
    public interface IBanned
    {
        bool Create(Banned banned);
        List<Banned> Getlist();
    }
}
