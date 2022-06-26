using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef
{
    public class ShopContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            // builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        public DbSet<CategoryDetail> categoryDetails { get; set; }
        private const string connectionString = @"
             Data Source=localhost,1433;
             Initial Catalog=shopdata;
             User ID=sa;Password=123456";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            // optionsBuilder.UseLazyLoadingProxies();
            Console.WriteLine("OnConfiguring");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Console.WriteLine("OnModelCreating");
            // var entity = modelBuilder.Entity(typeof(Product));
            // var entity1 = modelBuilder.Entity<Product>();
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("SanPham"); // ten bang
                entity.HasKey(p => p.ProductId);// tuong ung [key]
                // index danh chi muc
                entity.HasIndex(p => p.Price).HasDatabaseName("index-sanpham-price");
                // relative
                entity.HasOne(p => p.Category) // tao quan he
                .WithMany(p => p.Products) // khong co thuoc tinh property san pham
                .HasForeignKey("CateId") // ten khoa ngoai
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Khoa_ngoai_san_pham_category")
                ;
                // Thiet lap Category
                // 1-1

            });

            //
            modelBuilder.Entity<Category>(e=>{
              e.HasOne(x=>x.categoryDetail)
              .WithOne(y=>y.category)
              .HasForeignKey<CategoryDetail>(y=>y.CategoryDetailId)
              .OnDelete(DeleteBehavior.Cascade);              

            });           
            //
            // modelBuilder.Entity<CategoryDetail>(p =>
            //     {
            //         p.HasOne(x => x.category)
            //          .WithOne(y => y.categoryDetail)
            //          .HasForeignKey<CategoryDetail>(y => y.CategoryDetailId)
            //          .OnDelete(DeleteBehavior.Cascade);
            // });

        }
    }
}