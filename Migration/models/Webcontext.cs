
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace migration
{

    public class WebContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public const string ConnectStrring = @"Data Source=localhost,1433;Initial Catalog=webdb;User ID=sa;Password=123456";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectStrring);
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());       // bật logger

        }
        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                    builder.AddConsole()
                           .AddFilter(DbLoggerCategory.Database.Command.Name,
                                    LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // tao quan he giua product n to category 1
            // modelBuilder.Entity<Product>(entity =>
            // {
            //     entity.ToTable("Product")
            //           .HasOne(x => x.Category)
            //           .WithMany(x => x.Products)
            //           .HasForeignKey(x => x.CategoryId)
            //           .HasConstraintName("PK_Product_Category_CategoryId");
            // });
            // config category to product           
            // modelBuilder.Entity<Order>().HasKey(sc => new { sc.CustomerId, sc.ProductId });
            // thiet lap nhieu nhieu
            modelBuilder.Entity<Order>()
                         .HasOne<Customer>(sc => sc.Customer)
                         .WithMany(s => s.Orders)
                         .HasForeignKey(sc => sc.CustomerId);

            modelBuilder.Entity<Order>()
                      .HasOne<Product>(sc => sc.Product)
                      .WithMany(s => s.Orders)
                      .HasForeignKey(sc => sc.ProductId);
            // tao index
            // categoryDetial           
            // end
            modelBuilder.Entity<Order>(or=>{
                or.HasIndex(x=> new {x.CustomerId, x.ProductId});
            });
            // Quan he 1-1
            modelBuilder.Entity<Category>(ct=>{
                ct.HasOne<CategoryDetail>(x=>x.CategoryDetail)
                  .WithOne(x=>x.Category)
                  .HasForeignKey<CategoryDetail>(x=>x.CategoryId);
            });
        }
    }

}