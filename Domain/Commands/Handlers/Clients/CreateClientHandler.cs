using Deposito.Domain.Commands.Request.Clients;
using Deposito.Domain.Commands.Responses.Clients;
using Deposito.Domain.Entites;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers
{
    public class CreateClientHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
    {
        private readonly ClientFirestoreService _clientFirestoreService;

        public CreateClientHandler(ClientFirestoreService clientFirestoreService) 
            => _clientFirestoreService = clientFirestoreService;

        public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
            };

            await _clientFirestoreService.AddClientAsync(client);

            return new CreateClientResponse
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone,
            };
        }
    }
}
