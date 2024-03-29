﻿using ProjectSEM3.DAL.Models.Enum.EnumCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjectSEM3.Dto
{
    public class ListCartDTO
    {
        public Guid Id { get; set; }
        public string Images { get; set; }
        public double TotalPrice { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } 
        public DateTime Created { get; set; }
        public StatusCart Status { get; set; }
        public int Phone { get; set; }
    }
}