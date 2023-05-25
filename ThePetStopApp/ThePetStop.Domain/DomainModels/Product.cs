using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThePetStop.Domain.DomainModels
{
    public class Product : BaseEntity
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public string ProductCategory { get; set; }
        [Required]
        public string ProductAnimal { get; set; }


        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
        public virtual ICollection<ProductInOrder> ProductInOrders { get; set; }
    }
}
