﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testBekind.Domain;

namespace testBekind.Application.Ports
{
    public interface IProductPort
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(string id);
        Task<IEnumerable<string>> GetAllCategoryAsync();
        Task<IEnumerable<Product>> GetProductByCategoryAsync(string name);
    }
}
