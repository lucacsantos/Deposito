using Deposito.Domain.Commands.Request.Clients;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult> Create(CreateClientRequest request)
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
    }
}
