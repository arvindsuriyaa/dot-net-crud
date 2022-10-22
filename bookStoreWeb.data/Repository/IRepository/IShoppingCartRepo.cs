using BookStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.data.Repository.IRepository
{
    public interface IShoppingCartRepo : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart ShoppingCart);
    }
}
