using BookStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.Data.Repository.IRepository
{
    public interface ICoverType : IRepository<CoverTypeModel>
    {
        void Update(CoverTypeModel CoverTypeModel);
    }
}
