using Deposito.Domain.Commands.Request.Clients;
using Deposito.Domain.Commands.Responses.Clients;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handlers.Clients
{
    public class GetClientsByIdHandler : IRequestHandler<GetClientByIdQuery, CreateClientResponse>
    {
        private static readonly List<Client> clients = CreateClientHandler.clients;

        public Task<CreateClientResponse> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = clients.FirstOrDefault(clients => clients.Id == request.Id);

            if (client is null)
                throw new Exception("Cliente não encontrado.");

            return Task.FromResult(new CreateClientResponse
            {
                Id = client.Id,
                Email = client.Email,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Phone = client.Phone,
            });
        }
    }
}
