using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbService
{
    public class DatabaseOrders
    {
        public void EnsurePopulate()
            {
                using (ApplicationContext db = new ApplicationContext())
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

        public void AddOrder(Order order)
        {
            using (ApplicationContext db = new ApplicationContext()
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public void GetOrder(int id)
        {
            using (ApplicationContext db = new ApplicationContext()
            {
                db.Orders.Include(e => e.OrderLines).ThenInclude(e => e.Product).FirstOrDefault(e => e.Id==id);
                
            }
        }
    }
}
