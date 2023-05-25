using System;
using System.Collections.Generic;
using System.Text;
using ThePetStop.Domain.DTO;

namespace ThePetStop.Services.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteProductFromSoppingCart(string userId, Guid productId);
        bool order(string userId);
    }
}
