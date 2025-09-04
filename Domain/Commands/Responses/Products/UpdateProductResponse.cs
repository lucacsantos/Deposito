namespace Deposito.Domain.Commands.Responses.Products
{
    public class UpdateProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageURL { get; set; } = string.Empty;    
    }
}
