using Microsoft.EntityFrameworkCore;

namespace AssesmentA.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Produk> Produks { get; set; }
}