using Deposito.Domain.Commands.Request.Clients;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handlers.Clients
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientRequest, Unit>
    {
        private static readonly List<Client> clients = CreateClientHandler.clients;

        public Task<Unit> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
        {
            var client = clients.FirstOrDefault(clients => clients.Id == request.Id);

            if (client is null)
                throw new Exception("Cliente não encontrado");
            
            clients.Remove(client);

            return Task.FromResult(Unit.Value);
        }
    }
}