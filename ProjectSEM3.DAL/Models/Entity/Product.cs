using ProjectSEM3.DAL.Models.Enum.EnumCart;
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
        [Required(ErrorMessage = "Please enter name product.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string Images { get; set; }
        public double price { get; set; }
        public StatusProduct StatusProduct { get; set; }
    }
}
