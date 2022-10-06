using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.CoreBusiness
{
    public class ProductStorage
    {
        public int StorageId { get; set; }
        public string Name { get; set; }=String.Empty;

        //not add navigation property from product to inventory and vice versa invQTY
        public int StorageQuantity { get; set; }

        public double Price { get; set; }
    }
}
