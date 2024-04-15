using Microsoft.EntityFrameworkCore;

namespace api;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Stock> Stock { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
