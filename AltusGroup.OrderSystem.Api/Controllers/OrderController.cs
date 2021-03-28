#region Namespace imports

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AltusGroup.OrderSystem.Entities;
using AltusGroup.OrderSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

#endregion

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AltusGroup.OrderSystem.Api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailsRepository _orderDetailsRepository;

        #region ctor

        public OrderController(IOrderRepository orderRepository, IOrderDetailsRepository orderDetailsRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }

        #endregion


        #region Actions - Order

        [HttpGet]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Order>> GetOrders()
        {
            var results = await _orderRepository.FindAll();
            
            return Ok(results);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<OrderItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems(int id)
        {
            var results = await _orderDetailsRepository.FindByOrderId(id);

            return Ok(results);
        }

        #endregion
    }
}
