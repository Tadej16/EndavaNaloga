using EndavaNaloga.Models;

namespace EndavaNaloga.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetFilteredList(string? name, decimal? minPrice, decimal? maxPrice, string? categoryName);
        Product GetProductById(Guid id);
        Product UpdateProduct(Guid id, Product product);
    }
}
