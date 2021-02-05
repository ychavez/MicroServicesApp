using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductByname(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string name);
        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string  id);
    }
}
