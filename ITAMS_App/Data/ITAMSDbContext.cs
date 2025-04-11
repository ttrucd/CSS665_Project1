using Microsoft.EntityFrameworkCore; 
using ITAMS_App.Models; 

namespace ITAMS_App.Data {

public class ITAMSDbContext : DbContext
{
    public ITAMSDbContext(DbContextOptions<ITAMSDbContext> options): base(options) {}

    public DbSet<Asset> Assets {get; set;}
    public DbSet<AssetType> AssetTypes { get; set; }
    public DbSet<Administrator> Administrators {get; set;}
    public DbSet<Employee> Employees {get; set;}
    public DbSet<SoftwareLicense> SoftwareLicense {get; set;}
    public DbSet<MaintenanceRecord> MaintenanceRecords {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Asset>().HasIndex(a => a.Asset_Id);
        modelBuilder.Entity<Asset>().HasIndex(a => a.Serial_Number).IsUnique();
        
        modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
        modelBuilder.Entity<Administrator>().HasIndex(a => a.Email).IsUnique();
        modelBuilder.Entity<SoftwareLicense>().HasIndex(l => l.License_Key).IsUnique();
    }
}
}
