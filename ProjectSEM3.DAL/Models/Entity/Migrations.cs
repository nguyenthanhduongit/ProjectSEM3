using ProjectSEM3.DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DAL.Models.Entity
{
    public class Migrations : DbContext
    {
        public Migrations() : base("name=ProjectSEM3")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Migrations, Configuration>("ProjectSEM3"));
        }
        public virtual DbSet<Banned> Banneds { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
