using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using Deposito.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
