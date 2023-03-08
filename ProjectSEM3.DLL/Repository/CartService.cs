using ProjectSEM3.DAL.Models.Entity;
using ProjectSEM3.DAL.Models.Enum.EnumCart;
using ProjectSEM3.DLL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSEM3.DLL.Repository
{
    public class CartService : ICart
    {
        private static Migrations dbcontext;

        public CartService()
        {
            dbcontext = new Migrations();
        }
       public List<Bill> ListCart(object session)
        {
           
           var query = dbcontext.Bills.Where(x => x.Status == StatusCart.StatusCart && x.CustomerId == );
            query.Where(x => x.Created == DateTime.Now.Date);
            
        }
    }
}
