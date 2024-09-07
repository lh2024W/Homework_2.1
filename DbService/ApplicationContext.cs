using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbService
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null;
        public DbSet<Order> Orders { get; set; } = null;
        public DbSet<OrderLine> OrderLines { get; set; } = null;


        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }
}
