﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DAL.Models.Entity
{
    public class Bill
    {
        [Key]
        public Guid Id { get; set; }
        public int Total { get; set; }
        public double TotalPrice { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
