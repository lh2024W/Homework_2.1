using DbService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using DbService;

namespace Homework_2._1
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }

    public class Program
    {
        private static DatabaseOrders databaseOrders;
        static void Main(string[] args)
        {
            databaseOrders = new DatabaseOrders();
            databaseOrders.EnsurePopulated();

            AddOrder();
            databaseOrders.GetOrder(1);
        }

        static void AddOrder ()
        {
            Order order = new Order
            {
                LongName = "Хачатрян Лилия",
                Address = "г.Одесса"
            };

            var pr1 = databaseOrders.GetProduct(2);
            var pr2 = databaseOrders.GetProduct(5);

            order.OrderLines.Add(new OrderLine
            {
                ProductId = pr1.Id,
                Quantity = 3
            });

            order.OrderLines.Add(new OrderLine
            {
                ProductId = pr2.Id,
                Quantity = 1
            });
            databaseOrders.AddOrder(order);
        }

        public static void GetOrder(int id)
        {
            var currentOrder = databaseOrders.GetOrder(id);
            if (currentOrder != null)
            {
                Console.WriteLine(currentOrder);
            }
                   
        }
    }


}
