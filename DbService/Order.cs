using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbService
{
    public class Order
    {
        public int Id { get; set; }
        public string LongName { get; set; }
        public string Address { get; set; }

        public List<OrderLine> OrderLines {  get; set; } = new List<OrderLine>();
    }
}
