using Deposito.Domain.Commands.Responses;
using MediatR;

namespace Deposito.Domain.Commands.Request
{
    public class CreateClientRequest : IRequest<CreateClientResponse>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
