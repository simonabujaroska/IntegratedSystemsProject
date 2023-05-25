using System;
using System.Collections.Generic;
using ThePetStop.Domain.Identity;

namespace ThePetStop.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public virtual ThePetStopApplicationUser Owner { get; set; }

        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
    }
}
