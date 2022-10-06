using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class MySQLContext : IdentityDbContext<IdentityUser>
{
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
    {

    }
    public DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}