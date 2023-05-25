
using Microsoft.AspNetCore.Identity;
using ThePetStop.Domain.DomainModels;

namespace ThePetStop.Domain.Identity
{
    public class ThePetStopApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserCart { get; set; }
    }
}
