namespace Deposito.Domain.Commands.Responses
{
    public class CreateProductResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageURL { get; set; } = string.Empty;
    }
}
