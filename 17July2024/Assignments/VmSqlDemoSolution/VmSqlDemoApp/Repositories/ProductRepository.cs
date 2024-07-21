using VmSqlDemoApp.Models;
using VmSqlDemoApp.Context;
using Microsoft.EntityFrameworkCore;
using VmSqlDemoApp.Exceptions;

namespace VmSqlDemoApp.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {

         private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Product> DeleteByKey(int key)
        {
            var product = await GetByKey(key);
            if (product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync(true);
                return product;
            }
            throw new ElementNotFoundException("Product");
        }

        public async Task<Product> GetByKey(int key)
        {
            var product = await _context.Products.FirstOrDefaultAsync(u => u.Id == key);

            if (product != null)
            {
                return product;
            }

            throw new ElementNotFoundException("Product");
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            if (products.Any())
            {
                return products;
            }

            throw new EmptyListException("Product");

        }

        public async Task<Product> Update(Product item)
        {
            var product = await GetByKey(item.Id);
            if (product != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return product;
            }
            throw new ElementNotFoundException("Product");
        }


    }
}
