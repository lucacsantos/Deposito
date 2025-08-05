namespace Deposito.Domain.Entites
{
    public class Product
    {
        public Guid Id { get; set;}
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public string ImageURL { get; set; } = string.Empty;
    }
}
