using EndavaNaloga.Models;

namespace EndavaNaloga.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetFilteredListByName(string name);
        List<Product> GetFilteredListByCategory(string category);
        List<Product> GetFilteredListByMinPrice(decimal price);
        List<Product> GetFilteredListByMaxPrice(decimal price);
        Product GetProductById(Guid id);
        Product UpdateProduct(Guid id, Product product);
    }
}
