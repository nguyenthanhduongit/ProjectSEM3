using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSEM3.Dto
{
    public class SearchBillDTO
    {
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public int Phone { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}