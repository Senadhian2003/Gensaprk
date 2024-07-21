using VmSqlDemoApp.Models;
using VmSqlDemoApp.Models.DTO;

namespace VmSqlDemoApp.Services.Interfaces
{
    public interface IProductService
    {

        public Task<List<Product>> GetProductsAsync();

        public Task<Product> AddnewProduct(AddNewProductDTO addNewProductDTO);
    }
}
