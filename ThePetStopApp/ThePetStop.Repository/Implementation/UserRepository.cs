using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThePetStop.Domain.Identity;
using ThePetStop.Repository;
using ThePetStop.Repository.Interface;

namespace ThePetStop.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ThePetStopApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ThePetStopApplicationUser>();
        }
        public IEnumerable<ThePetStopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public ThePetStopApplicationUser Get(string id)
        {
            return entities
               .Include(z => z.UserCart)
               .Include("UserCart.ProductInShoppingCarts")
               .Include("UserCart.ProductInShoppingCarts.CurrentProduct")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(ThePetStopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ThePetStopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(ThePetStopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
