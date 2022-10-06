using ECommerceProductAPI.Infrastructure.Data.Repositories;
using System.Text;

namespace ECommerceProductAPI.Domain 
{
    public class ProductService : IProductService {
        private readonly ProductRepository _productRepository;
        public ProductService (ProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<Product> Create(ProductDTO productDTO) {
            Product product = new Product()
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Inventory = productDTO.Inventory,
                Photo = Encoding.ASCII.GetBytes(productDTO.Photo),
                CreatedAt = DateTime.Now,
                Category = productDTO.Category
            };

            return await _productRepository.Create(product);
        }

        public async Task<List<Product>> ListAll()
        {
            List<Product> products = await _productRepository.ListAll();
            return products;
        }

        public async Task<List<Product>> ListByCategory(string category)
        {
            List<Product> products = await _productRepository.ListByCategory(category);
            return products;
        }

        public async Task<int> Update(Product product)
        {
            return await _productRepository.Update(product);
        }

        public async Task<bool> Delete(int productId)
        {
            return await _productRepository.Delete(productId);
        }

        Task<Product> IProductService.Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

