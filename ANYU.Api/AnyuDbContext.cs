using ANYU.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ANYU.Api;

public class AnyuDbContext : DbContext
{
    public AnyuDbContext(DbContextOptions<AnyuDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
