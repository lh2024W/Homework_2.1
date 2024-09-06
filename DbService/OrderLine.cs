using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbService
{
    public class OrderLine
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }


        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
