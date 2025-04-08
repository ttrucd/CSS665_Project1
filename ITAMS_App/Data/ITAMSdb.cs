using Microsoft.EntityFrameworkCore; 
using ITAMS_App; 

public class ITAMSdb : DbContext
{
    public ITAMSdb (DbContextOptions<ITAMSdb> options): base(options) {}

    public DbSet<Asset> Assets {get; set;}
    public DbSet<Administrator> Administrators {get; set;}
    public DbSet<Employee> Employees {get; set;}
    public DbSet<SoftwareLicense> SoftwareLicense {get; set;}
    public DbSet<MaintenanceRecord> MaintenanceRecords {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Asset>().HasIndex(a => a.Serial_Number).IsUnique();
        modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
        modelBuilder.Entity<Administrator>().HasIndex(a => a.Email).IsUnique();
        modelBuilder.Entity<SoftwareLicense>().HasIndex(l => l.License_Key).IsUnique();
    }
}
