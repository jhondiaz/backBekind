using testBekind.Application.Ports;
using testBekind.Domain;
using testBekind.Domain.Interfaces;

namespace testBekind.Application.UseCases
{


    public class ProductInteractor : IProductPort
    {

        private IProductRepository _productRepository;

        public ProductInteractor(IProductRepository productRepository)
        {

            _productRepository = productRepository;

        }



        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }
        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string name)
        {
            return await _productRepository.GetProductByCategoryAsync(name);
        }


        public async Task<IEnumerable<string>> GetAllCategoryAsync()
        {
            return await _productRepository.GetAllCategoryAsync();
        }


        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            return _productRepository.UpdateProductAsync(product);
        }

        public Task<bool> DeleteProductAsync(string id)
        {
            return _productRepository.DeleteProductAsync(id);
        }
    }
}
