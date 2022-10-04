﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.Models
{
    public class ShoppingCart
    {

        public ProductModel Product { get; set; }

        [Range(1, 1000, ErrorMessage = "Enter range b/w 1 and 1000")]
        public int Count { get; set; }

    }
}
