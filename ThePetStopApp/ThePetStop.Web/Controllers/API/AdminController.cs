using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ThePetStop.Domain.DomainModels;
using ThePetStop.Domain.DTO;
using ThePetStop.Domain.Identity;
using ThePetStop.Services.Interface;

namespace ThePetStop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ThePetStopApplicationUser> _userManager;


        public AdminController(IOrderService orderService, UserManager<ThePetStopApplicationUser> userManager)
        {
            _orderService = orderService;
            this._userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            var result = this._orderService.getAllOrders();
            return result;
        }
        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {

            return this._orderService.getOrderDetails(model);
        }
        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDto> model)
        {
            bool status = true;
            foreach (var item in model)
            {
                var userCheck = _userManager.FindByEmailAsync(item.Email).Result;
                if (userCheck == null)
                {
                    var user = new ThePetStopApplicationUser
                    {
                        FirstName = item.Name,
                        LastName = item.LastName,
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PhoneNumber = item.PhoneNumber,
                        UserCart = new ShoppingCart()
                    };
                    var result = _userManager.CreateAsync(user, item.Password).Result;
                    status = status && result.Succeeded;
                }
                else
                {
                    continue;
                }
            }
            return status;
        }
    }
}
