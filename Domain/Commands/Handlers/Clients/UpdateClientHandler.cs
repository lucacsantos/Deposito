using Deposito.Domain.Commands.Request.Clients;
using Deposito.Domain.Commands.Responses.Clients;
using Deposito.Domain.Entites;
using MediatR;

namespace Deposito.Domain.Commands.Handlers.Clients
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
    {
        private static readonly List<Client> clients = CreateClientHandler.clients;

        public Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            var client = clients.FirstOrDefault(c => c.Id == request.Id);
            if (client is null)
                throw new Exception("Cliente não encontrato.");
            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.Email = request.Email;
            client.Phone = request.Phone;

            return Task.FromResult(new UpdateClientResponse
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