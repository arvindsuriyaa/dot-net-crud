
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ListCart { get; set; }
        public double OrderTotal { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
