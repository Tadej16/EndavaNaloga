namespace EndavaNaloga.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public Product() 
        { 
        }
        public Product(string name, decimal price, int cathegory)
        {
            Name = name;
            Price = price;
            CategoryId = cathegory;
        }

        public Product(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            CategoryId = product.CategoryId;
        }
    }
}
