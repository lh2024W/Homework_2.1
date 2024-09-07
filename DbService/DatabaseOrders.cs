using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbService
{
    public class DatabaseOrders
    {
        DbContextOptions<ApplicationContext> options;
        public void EnsurePopulated()
        {

            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");


            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                List<Product> products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Морковь",
                            Price = 19.00,
                            Producer = "Украина"
                        },
                        new Product
                        {
                            Name = "Помидор",
                            Price = 65.40,
                            Producer = "Турция"
                        },
                        new Product
                        {
                            Name = "Oгурец",
                            Price = 85.99,
                            Producer = "Турция"
                        },
                        new Product
                        {
                            Name = "Картофель",
                            Price = 25.10,
                            Producer = "Украина"
                        },
                        new Product
                        {
                            Name = "Свекла",
                            Price = 33.25,
                            Producer = "Украина"
                        }
                    };
                db.Products.AddRange(products);
                db.SaveChanges();
            }
        }

        public Product? GetProduct(int id)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                return db.Products.FirstOrDefault(e => e.Id==id);

            }
        }
        public void AddOrder(Order order)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public Order? GetOrder(int id)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                return db.Orders.Include(e => e.OrderLines).ThenInclude(e => e.Product).FirstOrDefault(e => e.Id==id);

            }
        }
    }
}