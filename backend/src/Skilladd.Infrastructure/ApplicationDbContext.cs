using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skilladd.Domain.Hiring.Classes;

namespace Skilladd.Infrastructure;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    private const string ConnectionStringName = "SkilladdDb";
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<JobPost> JobPosts => Set<JobPost>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString(ConnectionStringName));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
    }
    
    private ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => { builder.AddConsole(); });
}