using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DAL.Models.Entity
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }   
        public string Password { get; set; }
    }
}
