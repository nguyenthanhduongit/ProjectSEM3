using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DAL.Models.Entity
{
    public class Banned
    {
        [Key]
        public Guid Id { get; set; }
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string Images { get; set; }
        public string Content { get; set; }
    }
}
