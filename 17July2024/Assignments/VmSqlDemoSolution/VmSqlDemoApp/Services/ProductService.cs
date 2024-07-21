using VmSqlDemoApp.Models;
using VmSqlDemoApp.Models.DTO;
using VmSqlDemoApp.Repositories;
using VmSqlDemoApp.Services.Interfaces;

namespace VmSqlDemoApp.Services
{
    public class ProductService : IProductService
    {

        public readonly IRepository<int, Product> _productRepository;
        public readonly IBlobService _blobService;


        public ProductService(IRepository<int, Product> productRepository, IBlobService blobService)
        {
            _productRepository = productRepository;
            _blobService = blobService;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _productRepository.GetAll();
            return products.ToList();
        }

        public async Task<Product> AddnewProduct(AddNewProductDTO addNewProductDTO)
        {

            var product = new Product
            {
                Name = addNewProductDTO.Name
            };

            await _productRepository.Add(product);

            string fileExtension = Path.GetExtension(addNewProductDTO.ProductImage.FileName);
            string blobName = $"product-{product.Id}{fileExtension}";
            string imageUrl = await _blobService.UploadImageAsync(addNewProductDTO.ProductImage, blobName);

            product.ImageDescription = imageUrl;

            await _productRepository.Update(product);

            return product;
        }


    }
}
