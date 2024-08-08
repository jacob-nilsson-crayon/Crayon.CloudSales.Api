using Crayon.CloudSales.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class CrayonCloudSalesDbContext : DbContext
{
    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<LicenseEntity> Licenses { get; set; }

    private readonly IConfiguration _configuration;

    public CrayonCloudSalesDbContext(DbContextOptions<CrayonCloudSalesDbContext> options)
        : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-P5K3EE0;Initial Catalog=Crayon;User ID=sa;Password=SqlServer;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountEntity>()
            .HasKey(a => a.ExternalId);

        modelBuilder.Entity<LicenseEntity>()
            .HasKey(l => l.Id);

        modelBuilder.Entity<AccountEntity>()
            .HasMany(a => a.Licenses)
            .WithOne()
            .HasForeignKey(l => l.ExternalAccountId);

        base.OnModelCreating(modelBuilder);
    }
}
