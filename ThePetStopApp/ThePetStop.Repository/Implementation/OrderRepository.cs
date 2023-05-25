using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ThePetStop.Domain.DomainModels;
using ThePetStop.Repository.Interface;

namespace ThePetStop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> getAllOrders()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.ProductInOrders)
                .Include("ProductInOrders.Product")
                .ToListAsync().Result;
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return entities
               .Include(z => z.User)
               .Include(z => z.ProductInOrders)
               .Include("ProductInOrders.Product")
               .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}
