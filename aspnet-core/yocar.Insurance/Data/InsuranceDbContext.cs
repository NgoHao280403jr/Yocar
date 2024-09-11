using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using yocar.Insurance.Entities.Brands;
using yocar.Insurance.Entities.Garages;
using yocar.Insurance.Entities.InsuranceCompanies;
using yocar.Insurance.Entities.Locations;
using yocar.Insurance.Entities.Wards;
using yocar.Insurance.Entities.Districts;
using yocar.Insurance.Entities.ProvinceCities;



namespace yocar.Insurance.Data;

public class InsuranceDbContext : AbpDbContext<InsuranceDbContext>
{
    public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
        : base(options)
    {
    }
    public DbSet<Garage> garages { get; set; } = null!;
    public DbSet<InsuranceCompany> insuranceCompany { get; set; } = null;
    public DbSet<location> locations { get; set; } = null!;
    public DbSet<Brand> brands { get; set; } = null!;
    public DbSet<Ward> Wards { get; set; } = null!;
    public DbSet<District> Districts { get; set; } = null!;
    public DbSet<ProvinceCity> ProvinceCities { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */
        builder.Entity<InsuranceCompany>(b =>
        {
            b.ToTable("InsuranceCompanies"); // Define the table name
            b.HasKey(ic => ic.Id); // Define primary key
            b.Property(ic => ic.name).IsRequired().HasMaxLength(250); // Configure Name column
            b.HasIndex(ic => ic.name).IsUnique(); // Ensure company name is unique
            b.Property(ic => ic.TenantId); // TenantId column (optional)
        });

        // Configure Garage entity
        builder.Entity<Garage>(b =>
        {
            b.ToTable("Garages"); // Define the table name
            b.HasKey(g => g.Id); // Define primary key
            b.Property(g => g.Name).IsRequired().HasMaxLength(250); // Configure Name column
            b.Property(g => g.Address).IsRequired().HasMaxLength(500); // Configure Address column
            b.Property(g => g.ContactPersonName).HasMaxLength(100); // Optional contact person name
            b.Property(g => g.ContactEmail).HasMaxLength(100); // Optional email
            b.Property(g => g.ContactPhone).HasMaxLength(15); // Optional phone
            b.Property(g => g.TenantId); // TenantId column (optional)

            // Configure the relationship with InsuranceCompany (many garages belong to one insurance company)
            b.HasOne(g => g.InsuranceCompany)
             .WithMany(ic => ic.Garages)
             .HasForeignKey(g => g.InsuranceCompanyId)
             .OnDelete(DeleteBehavior.Cascade); // Cascade delete if InsuranceCompany is removed

            // Configure the optional relationship with Brand (if needed)
            b.HasOne(g => g.Brand)
             .WithMany() // Assuming Brand entity exists, configure accordingly
             .HasForeignKey(g => g.BrandId)
             .OnDelete(DeleteBehavior.SetNull); // Set null if Brand is removed
        });

        // Configure Location entity
        builder.Entity<location>(b =>
        {
            b.ToTable("Locations");
            b.HasKey(l => l.Id); // Đảm bảo Id được sử dụng là từ lớp cơ sở
            b.Property(l => l.Latitude).IsRequired();
            b.Property(l => l.Longitude).IsRequired();
            b.Property(l => l.Address).HasMaxLength(500);
            b.HasOne(l => l.Garage)
             .WithMany(g => g.Locations)
             .HasForeignKey(l => l.GarageID)
             .OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Ward>(b =>
        {
            b.ToTable("Wards"); 
            b.HasKey(w => w.Id); 
            b.Property(w => w.Name)
             .IsRequired() 
             .HasMaxLength(255);           
            b.Property(w => w.Description)
             .IsRequired() 
             .HasMaxLength(1000);            
            b.Property(w => w.Slug)
             .IsRequired() 
             .HasMaxLength(255);             
            b.Property(w => w.DistrictId)
             .IsRequired(); 
            b.HasOne<District>() 
             .WithMany() 
             .HasForeignKey(w => w.DistrictId) 
             .OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<ProvinceCity>(b =>
        {
            b.ToTable("ProvinceCities"); 
            b.HasKey(pc => pc.Id); 
            b.Property(pc => pc.Name)
             .IsRequired() 
             .HasMaxLength(255);          
            b.Property(pc => pc.Slug)
             .IsRequired() 
             .HasMaxLength(255); 
            b.Property(pc => pc.Description)
             .IsRequired() 
             .HasMaxLength(1000); 
        });
        builder.Entity<District>(b =>
        {
            
            b.ToTable("Districts");
            b.ConfigureByConvention();
            b.Property(x => x.Name)
                .IsRequired() 
                .HasMaxLength(200); 
            b.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(200);
            b.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);
            b.HasOne<ProvinceCity>()
                .WithMany()
                .HasForeignKey(x => x.ProvinceCityId)
                .IsRequired() 
                .OnDelete(DeleteBehavior.NoAction);
            b.HasIndex(x => x.Name);
        });


    }
}
