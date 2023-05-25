using System;
using ThePetStop.Domain.DomainModels;

namespace ThePetStop.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Product SelectedProduct { get; set; }
        public Guid SelectedProductId { get; set; }
        public int Quantity { get; set; }
    }
}
