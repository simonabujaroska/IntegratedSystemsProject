using System;

namespace ThePetStop.Domain.DomainModels
{
    public class ProductInShoppingCart : BaseEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product CurrentProduct { get; set; }

        public Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}
