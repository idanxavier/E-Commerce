using Microsoft.EntityFrameworkCore;

namespace ECommerceProductAPI.Infrastructure.Data.Repositories
{
    public class ProductRepository
    {
        private readonly MySQLContext _context;

        public ProductRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            var ret = await _context.Product.AddAsync(product);

            await _context.SaveChangesAsync();

            ret.State = EntityState.Detached;

            return ret.Entity;
        }

        public async Task<List<Product>> ListAll()
        {
            List<Product> products = await _context.Product.ToListAsync();
            return products;
        }

        public async Task<List<Product>> ListByCategory(string category)
        {
            List<Product> products = await _context.Product.Where(p => p.Category.Equals(category)).ToListAsync();
            return products;
        }

        public async Task<int> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int productId)
        {
            var item = await _context.Product.FindAsync(productId);
            _context.Product.Remove(item);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
