using Deposito.Domain.Commands.Request.Clients;
using Deposito.Domain.Commands.Responses.Clients;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handlers.Clients
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<CreateClientResponse>>
    {
        private static readonly List<Client> clients = CreateClientHandler.clients;

        public Task<IEnumerable<CreateClientResponse>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var response = clients.Select(c => new CreateClientResponse
            {
                Id = c.Id,
                Email = c.Email,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Phone = c.Phone
            });

            return Task.FromResult(response);
        }
    }
} 
