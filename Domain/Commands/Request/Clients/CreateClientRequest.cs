using Deposito.Domain.Commands.Responses.Clients;
using MediatR;

namespace Deposito.Domain.Commands.Request.Clients
{
    public class CreateClientRequest : IRequest<CreateClientResponse>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
