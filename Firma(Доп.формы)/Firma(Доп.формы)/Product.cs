using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Доп.формы_
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
