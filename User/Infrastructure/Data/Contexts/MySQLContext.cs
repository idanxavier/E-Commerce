namespace ECommerceUserAPI;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

public class MySQLContext : IdentityDbContext<IdentityUser>
{
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
    {

    }

    // public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // builder.Entity<User>().ToTable("AspNetUsers").HasKey(t => t.Id);
    }
}