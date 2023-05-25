using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThePetStop.Domain.DomainModels;
using ThePetStop.Domain.DTO;
using ThePetStop.Repository.Interface;
using ThePetStop.Services.Interface;

namespace ThePetStop.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<ProductInOrder> _productInOrderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<EmailMessage> _mailRepository;

        public ShoppingCartService(IRepository<EmailMessage> mailRepository, IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository, IRepository<Order> orderRepository, IRepository<ProductInOrder> productInOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _productInOrderRepository = productInOrderRepository;
            _mailRepository = mailRepository;
        }


        public bool deleteProductFromSoppingCart(string userId, Guid productId)
        {
            if (!string.IsNullOrEmpty(userId) && productId != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.ProductInShoppingCarts.Where(z => z.ProductId.Equals(productId)).FirstOrDefault();

                userShoppingCart.ProductInShoppingCarts.Remove(itemToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);

                return true;
            }
            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userCard = loggedInUser.UserCart;

                var allProducts = userCard.ProductInShoppingCarts.ToList();

                var allProductPrices = allProducts.Select(z => new
                {
                    ProductPrice = z.CurrentProduct.ProductPrice,
                    Quantity = z.Quantity
                }).ToList();

                double totalPrice = 0.0;

                foreach (var item in allProductPrices)
                {
                    totalPrice += item.Quantity * item.ProductPrice;
                }

                var reuslt = new ShoppingCartDto
                {
                    Products = allProducts,
                    TotalPrice = totalPrice
                };

                return reuslt;
            }
            return new ShoppingCartDto();
        }

        public bool order(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);
                var userCard = loggedInUser.UserCart;

                EmailMessage message = new EmailMessage();
                message.MailTo = loggedInUser.Email;
                message.Subject = "Order created";
                message.Status = false;


                Order order = new Order
                {
                    Id = Guid.NewGuid(), // za id-to da ne e 0000....
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepository.Insert(order);

                List<ProductInOrder> productInOrders = new List<ProductInOrder>();

                var result = userCard.ProductInShoppingCarts.Select(z => new ProductInOrder
                {
                    Id = Guid.NewGuid(),
                    ProductId = z.CurrentProduct.Id,
                    Product = z.CurrentProduct,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = z.Quantity
                }).ToList();

                var totalPrice = 0.0;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Completed order. The order contains: ");
                for(int i= 1; i<= result.Count(); i++)
                {
                    var item = result[i - 1];
                    totalPrice = item.Quantity * item.Product.ProductPrice;
                    sb.AppendLine(i.ToString() + ". " + item.Product.ProductName + " with price of " + item.Product.ProductPrice + " and quantity of: " + item.Quantity + ".");
                }
                sb.AppendLine("Total price: " + totalPrice.ToString());
                message.Content = sb.ToString();    

                productInOrders.AddRange(result);

                foreach (var item in productInOrders)
                {
                    this._productInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.ProductInShoppingCarts.Clear();
                this._mailRepository.Insert(message);

                this._userRepository.Update(loggedInUser);

                return true;
            }

            return false;
        }
    }
}
