using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DAL.Models.Entity
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string Images { get; set; }
        public double price { get; set; }
        

    }
}
