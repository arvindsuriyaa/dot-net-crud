using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ValidateNever]
        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }

        [Range(1, 1000, ErrorMessage = "Enter range b/w 1 and 1000")]
        public int Count { get; set; }

        public string ApplicationUserId{ get; set; }
        [ValidateNever]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUsers ApplicationUsers{ get; set; }
        [NotMapped]
        public double Price{ get; set; }

    }
}
