using System;
using System.Collections.Generic;
using System.Text;
using ThePetStop.Domain.DomainModels;
using ThePetStop.Repository.Interface;
using ThePetStop.Services.Interface;

namespace ThePetStop.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}
