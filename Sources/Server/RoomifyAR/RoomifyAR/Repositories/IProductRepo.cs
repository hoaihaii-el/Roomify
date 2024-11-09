using RoomifyAR.Entities;
using RoomifyAR.Requests;
using RoomifyAR.Specifications;

namespace RoomifyAR.Repositories
{
    public interface IProductRepo
    {
        Task<Product> Add(ProductRequest product);
        Task Update(Product product);
        Task<IReadOnlyList<Product>> GetProductsWithSpec(ProductSpec spec);
        Task<IReadOnlyList<Product>> GetNewArrival();
        Task<IReadOnlyList<Product>> GetBestSeller();
        Task<Product> GetProductById(int id);
        Task<IReadOnlyList<Product>> GetByCategory(int cateId);
        Task Delete(int id);
    }
}
