using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Product 
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Info()
        {
            return "---Info method---";
        }
    }
}
