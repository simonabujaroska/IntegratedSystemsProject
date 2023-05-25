﻿using System;
using System.Collections.Generic;
using System.Text;
using ThePetStop.Domain.DomainModels;
using ThePetStop.Domain.DTO;

namespace ThePetStop.Services.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Product p);
        void UpdeteExistingProduct(Product p);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
        void DeleteProduct(Guid id);
        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}
