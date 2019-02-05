using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public class Product
    {
        public int id { get; set; }
        public Consumer consumer { get; set; }
        public List<Vehicle> vehicle { get; set; }
        public Coverage coverage { get; set; }
    }
}
