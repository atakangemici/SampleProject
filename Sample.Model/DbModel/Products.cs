using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.DbModel
{
    public class Products : BaseEntity
    {
        public string Name { get; set; }

        public string Barcode { get; set; }

        public double Price { get; set; }

        public string Pictures { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

    }
}
