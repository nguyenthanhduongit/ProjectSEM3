using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DAL.Models.Enum
{
    namespace EnumCart
    {
      public  enum  StatusCart
        {
            //Giỏ hàng
            StatusCart = 0,
            //bill 
            StatusBill = 1,
            
        }
        public enum StatusProduct
        {
            ProductNew = 0,
            ProductSeller = 1,
            ProductRecently = 2,
        }
    }
}
