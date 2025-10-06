using Deposito.Domain.Commands.Request.Clients;
using Deposito.Domain.Commands.Responses.Clients;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers.Clients
{
    public class GetClientsByIdHandler : IRequestHandler<GetClientByIdQuery, CreateClientResponse>
    {
        private readonly ClientFirestoreService _clientFirestoreService;

        public GetClientsByIdHandler(ClientFirestoreService clientFirestoreService)
        {
            _clientFirestoreService = clientFirestoreService;
        }
        public async Task<CreateClientResponse> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientFirestoreService.GetClientAsyncId(request.Id);

            if (client is null)
                throw new Exception("Cliente não encontrado.");

            return new CreateClientResponse
            {
                Id = client.Id,
                Email = client.Email,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Phone = client.Phone,
            };
        }
    }
}
