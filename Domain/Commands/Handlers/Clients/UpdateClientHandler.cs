using Deposito.Domain.Commands.Request.Clients;
using Deposito.Domain.Commands.Responses.Clients;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers.Clients
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
    {
        private readonly ClientFirestoreService _clientFirestoreService;

        public UpdateClientHandler(ClientFirestoreService clientFirestoreService)
        {
            _clientFirestoreService = clientFirestoreService;
        }

        public async Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            var client =  await _clientFirestoreService.GetClientAsyncId(request.Id);

            if (client is null)
                throw new Exception("Cliente não encontrato.");

            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.Email = request.Email;
            client.Phone = request.Phone;

            await _clientFirestoreService.UpdateClientAsync(client);

            return new UpdateClientResponse
            {
                Id = Guid.Parse(client.Id),
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone,
            };
        }

    }
}