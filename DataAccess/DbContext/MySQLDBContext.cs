using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApiNet.models;

public class MySQLDBContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ProductConfiguration());

        // builder.Entity<ProductModel>()
        //     .ToTable("Products");
        // builder.Entity<UserModel>()
        //     .ToTable("Users");
        builder.Entity<ProductColor>()
            .ToTable("ProductColors");
        builder.Entity<ProductSize>()
            .ToTable("ProductSizes");
        builder.Entity<ProductImage>()
            .ToTable("ProductImages");

    }
    public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("Products").HasKey(p => p.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Stock).IsRequired().HasDefaultValue(0);
        }
    }
}