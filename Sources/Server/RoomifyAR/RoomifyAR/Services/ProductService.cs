using Microsoft.EntityFrameworkCore;
using RoomifyAR.Entities;
using RoomifyAR.Repositories;
using RoomifyAR.Specifications;
using System.Linq.Expressions;

namespace RoomifyAR.Services
{
    public class ProductService(DataContext _context) : IProductRepo
    {
        public async Task<Product> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            if (product.Medias != null && product.Medias.Any())
            {
                _context.ProductMedias.AddRange(product.Medias);
            }
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsWithSpec(ProductSpec spec)
        {
            var products = _context.Products
                .Where(p =>
                    (string.IsNullOrEmpty(spec.Search) || p.Name.ToLower().Contains(spec.Search)))
                .AsNoTracking()
                .AsQueryable();

            Expression<Func<Product, object>> keySelector = p => p.Id;
            if (!string.IsNullOrEmpty(spec.SortCol))
            {
                keySelector = spec.SortCol.ToLower() switch
                {
                    "name" => p => p.Name,
                    "price" => p => p.Price,
                    _ => p => p.Id
                };
            }

            if (spec.SortType == null || spec.SortType.Contains("asc", StringComparison.OrdinalIgnoreCase))
            {
                products = products.OrderBy(keySelector);
            }
            else
            {
                products = products.OrderByDescending(keySelector);
            }

            if (spec.PageSize > 0)
            {
                products = products.Skip((spec.PageIndex - 1) * spec.PageSize).Take(spec.PageSize);
            }

            return await products.Include(p => p.Medias).ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetBestSeller()
        {
            return await _context.Products
                .OrderBy(p => p.Stock)
                .Take(8)
                .Include(p => p.Medias)
                .AsNoTracking()
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetByCategory(int cateId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == cateId)
                .Include(p => p.Medias)
                .AsNoTracking()
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetNewArrival()
        {
            return await _context.Products
                .OrderByDescending(p => p.Id)
                .Take(8)
                .Include(p => p.Medias)
                .AsNoTracking()
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var result = await _context.Products
                .Where(p => p.Id == id)
                .Include(p => p.Medias)
                .AsNoTracking()
                .AsQueryable()
                .FirstOrDefaultAsync();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }



        public async Task Update(Product product)
        {
            _context.Products.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Remove(product ?? throw new KeyNotFoundException());
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
