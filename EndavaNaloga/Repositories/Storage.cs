using EndavaNaloga.Models;

namespace EndavaNaloga.Repositories
{
    public class Storage : IProductRepository
    {
        private List<Product> products = new()
        {
            new Product("Laptop", 1200.00m, 1),
            new Product("Smartphone", 800.00m, 1),
            new Product("Tablet", 400.00m, 1),
            new Product("Headphones", 150.00m, 2),
            new Product("Smartwatch", 200.00m, 2),
            new Product("Camera", 600.00m, 3),
            new Product("Printer", 250.00m, 3),
            new Product("Monitor", 300.00m, 4),
            new Product("Keyboard", 100.00m, 4),
            new Product("Mouse", 50.00m, 4)
        };

        private readonly List<Category> categories = new()
        {
            new Category(1, "Electronics", "Electronic goods"),
            new Category(2, "Accessories", "Random accessories"),
            new Category(3, "Office Equipment", "Paperclips and such"),
            new Category(4, "Computer Peripherals", "Mice")
        };
        public List<Product> GetFilteredList(string? name, decimal? minPrice, decimal? maxPrice, string? categoryName)
        {
            Category temp = getCategoryByName(categoryName);
            return products
                .Where(x=>string.IsNullOrEmpty(name) || x.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Where(x=>minPrice == null || x.Price >= minPrice.Value)
                .Where(x=>maxPrice == null || x.Price >= maxPrice.Value)
                .Where(x=>temp == null || x.CategoryId == temp.Id).ToList();
        }

        private Category getCategoryByName(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return null;
            }
            return categories.Where(x => x.Name.Contains(categoryName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
        public Product GetProductById(Guid id)
        {
            return products.Where(x => x.Id == id).FirstOrDefault();
        }

        public Product UpdateProduct(Guid id, Product product)
        {
            Product toUpdate = GetProductById(id);
            if (toUpdate == null)
            {
                return null;
            }
            toUpdate.Name = product.Name;
            toUpdate.Price = product.Price;
            toUpdate.CategoryId = product.CategoryId;
            return toUpdate;
        }
    }
}
