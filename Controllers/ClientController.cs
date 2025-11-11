using Deposito.Domain.Commands.Request;
using Deposito.Domain.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Deposito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateClientRequest request)
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
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateClientRequest request)
        {
            if (id != request.Id)
                return BadRequest("O Id não existe");
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

        [HttpGet]
        public async Task<ActionResult<CreateClientResponse>> GetAll()
        {
            var result = await _mediator.Send(new GetAllClientsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateClientResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetClientByIdQuery(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteClientRequest(id));
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}