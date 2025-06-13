using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Dal;

public class DatabaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    public DbSet<SeedlingBatch> SeedlingBatches { get; set; }
    public DbSet<TreeSpecies> TreeSpecies { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
}