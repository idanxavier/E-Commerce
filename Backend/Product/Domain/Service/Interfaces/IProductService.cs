namespace ECommerceProductAPI.Domain
{
    public interface IProductService
    {
        Task<Product> Create(ProductDTO productDTO);
        Task<List<Product>> ListAll();
        Task<List<Product>> ListByCategory(string category);
        Task<Product> Update(Product product);
        Task<bool> Delete(int productId);
    }
}

