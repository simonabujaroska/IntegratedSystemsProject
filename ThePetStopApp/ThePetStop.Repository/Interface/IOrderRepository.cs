using System;
using System.Collections.Generic;
using System.Text;
using ThePetStop.Domain.DomainModels;

namespace ThePetStop.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);

    }
}
