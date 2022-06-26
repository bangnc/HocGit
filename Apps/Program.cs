using System;
using Microsoft.EntityFrameworkCore;
namespace ef
{

    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ShopContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            Console.WriteLine(dbname);
            var kq = dbcontext.Database.EnsureCreated();
            if (kq)
            {
                Console.WriteLine("Tao thanh cong");
            }
            else
            {
                Console.WriteLine("Khong tao duoc");
            }
        }
        static void DropDatabase()
        {
            using var dbcontext = new ShopContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            Console.WriteLine(dbname);
            var kq = dbcontext.Database.EnsureDeleted();
            if (kq)
            {
                Console.WriteLine("Xoa thanh cong");
            }
            else
            {
                Console.WriteLine("Xoa tao duoc");
            }
        }


        static void InsertData()
        {
            using var dbContext = new ShopContext();
            var c1 = new Category()
            {
                Description = "Cac loai dien thoai",
                Name = "Dien thoai"
            };
            var c2 = new Category()
            {
                Description = "Cac loai do uong",
                Name = "Do uong"
            };
            dbContext.Add(new Product() { Name = "Iphone8", Price = 1000, CateId = 1 });
            dbContext.Add(new Product() { Name = "Samsung", Price = 900, CateId = 1 });
            dbContext.Add(new Product() { Name = "Ruou Vang ABC", Price = 1000, CateId = 2 });
            dbContext.Add(new Product() { Name = "Cafe ABC", Price = 9000, CateId = 2 });

            dbContext.categories.Add(c2);
            dbContext.SaveChanges();
        }
        static void Main(string[] agrs)
        {
            // var dbContext = new ProductContext();

            DropDatabase();
            CreateDatabase();
            // InsertProduct();
            // ReadProducts();
            // InsertData();
            // using var dbContext = new ShopContext();
            // var product = (from p in dbContext.products
            //               where p.ProductId == 3 
            //               select p).FirstOrDefault();

            // product.PrintInfo();
            // var e = dbContext.Entry(product);
            // e.Reference(p=>p.Category).Load();

            // if(product.Category != null)
            // {
            //     Console.WriteLine($" {product.Category.Name} - {product.Category.Description}");
            // }
            // else {
            //     Console.WriteLine("Category == null");
            // }
            //  using var dbContext = new ShopContext();
            // var cate = (from p in dbContext.categories
            //               where p.CategoryId == 1
            //               select p).FirstOrDefault();

            // if(cate.Products != null)
            // {
            //     Console.WriteLine($"So san pham {cate.Products.Count}");
            //     cate.Products.ForEach(p=>p.PrintInfo());
            // }
            // else {
            //     Console.WriteLine("Products == null");
            // }
        }
    }
}
