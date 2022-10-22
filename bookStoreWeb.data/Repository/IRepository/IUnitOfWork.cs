using BookStoreWeb.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategory Category { get; }
        void Save();
        ICoverType CoverType { get; }
        IProductRepository Products { get; }
        ICompany Company { get; }
        IApplicationUsersRepo ApplicationUsers { get; }
        IShoppingCartRepo ShoppingCart { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }

    }
}
