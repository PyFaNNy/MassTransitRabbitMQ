using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Producer.ModelsDTO;
using SharedModels;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDto)
        {
            await _publishEndpoint.Publish<OrderCreated>(new
            {
                Id = new Guid("e2a18abf-2b5c-47e7-bbbd-08c0f2aad006"),
                orderDto.ProductName,
                orderDto.Price
            });

            return Ok();
        }
    }
}
