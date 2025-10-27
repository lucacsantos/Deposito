using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Deposito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create (CreateOrderRequest request)
        {
            var result = await _mediator.Send(request);

            try
            {
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update (Guid id, [FromBody] UpdateOrderRequest request)
        {
            if (id != request.Id)
                return BadRequest("O Id não esxiste");
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteOrderRequest(id));
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<CreateOrderResponse>> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateOrderResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetOrderByIdQuery(id));
                return Ok(result);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
            
        }
    }
}
