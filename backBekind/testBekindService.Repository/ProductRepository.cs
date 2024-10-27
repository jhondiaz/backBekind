using MongoDB.Driver;
using testBekind.Domain;
using testBekind.Domain.Interfaces;
using testBekindService.DataContexts;

namespace testBekindService.Repository
{


    public class ProductRepository : IProductRepository
    {
        private readonly MongoContext _context;

        public ProductRepository(MongoContext context)
        {

            _context = context;

        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string name)
        {
            return await _context.Products.Find(p => p.Category == name).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllCategoryAsync()
        {
            return (await _context.Products.Find(_ => true).ToListAsync())
                .GroupBy(g=>g.Category)
                .Select(c=>c.Key).ToList();
        }


        public async Task AddProductAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var result = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var result = await _context.Products.DeleteOneAsync(p => p.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }


    }




}
