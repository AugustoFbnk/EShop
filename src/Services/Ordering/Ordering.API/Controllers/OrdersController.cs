using Microsoft.AspNetCore.Mvc;
using Ordering.API.Application.Queries;
using System.Net;

namespace Ordering.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderQueries _orderQueries;

        public OrdersController(IOrderQueries orderQueries)
        {
            _orderQueries = orderQueries ?? throw new ArgumentNullException(nameof(orderQueries));
        }

        [Route("{orderId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(Application.Queries.Order), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetOrderAsync(int orderId)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var order = await _orderQueries.GetOrderAsync(orderId);

                return Ok(order);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
