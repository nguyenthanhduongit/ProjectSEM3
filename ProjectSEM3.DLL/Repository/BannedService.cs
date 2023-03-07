using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DLL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DLL.Repository
{
    public class BannedService : IBanned
    {
        private static Migrations dbcontext;
        public BannedService()
        {
            dbcontext = new Migrations();
        }
        public bool Create(Banned banned)
        {
            if (banned == null)
                return false;

           var data = dbcontext.Banneds.Add(banned);
            dbcontext.SaveChanges();
            if (data == null) return false;
            return true;
        }

        public List<Banned> Getlist()
        {
            return dbcontext.Banneds.ToList();
        }
    }
}
