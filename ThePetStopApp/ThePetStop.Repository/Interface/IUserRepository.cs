using System;
using System.Collections.Generic;
using System.Text;
using ThePetStop.Domain.Identity;

namespace ThePetStop.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ThePetStopApplicationUser> GetAll();
        ThePetStopApplicationUser Get(string id);
        void Insert(ThePetStopApplicationUser entity);
        void Update(ThePetStopApplicationUser entity);
        void Delete(ThePetStopApplicationUser entity);
    }
}
