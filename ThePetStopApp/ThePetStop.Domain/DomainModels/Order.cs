using System;
using System.Collections.Generic;
using ThePetStop.Domain.Identity;

namespace ThePetStop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ThePetStopApplicationUser User { get; set; }

        public virtual ICollection<ProductInOrder> ProductInOrders { get; set; }
    }
}
