using Microsoft.EntityFrameworkCore;
using Skilladd.Domain.Hiring.Classes;

namespace Skilladd.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<JobPost> JobPosts => Set<JobPost>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("");
    }
    
}