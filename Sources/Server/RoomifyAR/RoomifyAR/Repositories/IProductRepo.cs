using RoomifyAR.Entities;
using RoomifyAR.Specifications;

namespace RoomifyAR.Repositories
{
    public interface IProductRepo
    {
        Task<Product> Add(Product product);
        Task Update(Product product);
        Task<IReadOnlyList<Product>> GetProductsWithSpec(ProductSpec spec);
        Task<IReadOnlyList<Product>> GetNewArrival();
        Task<IReadOnlyList<Product>> GetBestSeller();
        Task<Product> GetProductById(int id);
        Task<IReadOnlyList<Product>> GetByCategory(int cateId);
        Task<IReadOnlyList<Category>> GetCategories();
        Task Delete(int id);
        Task AddTaskCreate3DModel(string imageUrl, int productId);
        Task<string> Get3DModel(int productId);
        Task Delete3DModel(int productId);
    }
}
