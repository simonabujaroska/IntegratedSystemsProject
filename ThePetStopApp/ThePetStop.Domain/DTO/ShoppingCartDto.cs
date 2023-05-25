using System.Collections.Generic;
using ThePetStop.Domain.DomainModels;

namespace ThePetStop.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<ProductInShoppingCart> Products { get; set; }

        public double TotalPrice { get; set; }
    }
}