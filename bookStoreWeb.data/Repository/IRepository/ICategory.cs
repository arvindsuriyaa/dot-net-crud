using BookStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.data.Repository.IRepository
{
    public interface ICategory : IRepository<Category>
    {
        void Update(Category category);

    }
}
