using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Human
    {
        private string _id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
