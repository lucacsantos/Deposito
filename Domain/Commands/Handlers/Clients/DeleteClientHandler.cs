using Deposito.Domain.Commands.Request.Clients;
using Deposito.Services;
using MediatR;

namespace Deposito.Domain.Commands.Handlers.Clients
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientRequest, Unit>
    {
        private readonly ClientFirestoreService _clientFirestoreService;

        public DeleteClientHandler(ClientFirestoreService clientFirestoreService)
        {
            _clientFirestoreService = clientFirestoreService;
        }

        public async Task<Unit> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientFirestoreService.GetClientAsyncId(request.Id);

            if (client is null)
                throw new Exception("Cliente não encontrado");

            await _clientFirestoreService.DeleteClientAsync(request.Id);

            return Unit.Value;
        }
    }
}