using Deposito.Domain.Commands.Request.Clients;
using Deposito.Domain.Commands.Responses.Clients;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class CreateClientHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
    {
        public static readonly List<Client> clients = new();

        public Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
            };

            clients.Add(client);

            return Task.FromResult(new CreateClientResponse
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone,
            });
        }
    }
}
