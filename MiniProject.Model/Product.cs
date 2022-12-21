using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Model
{
    public class Product
    {
        public int productID { get; set; }

        public string productName { get; set; }

        public int supplierID { get; set; }

        public int categoryID { get; set;}

        public string quantityPerUnit { get; set; }

        public decimal unitPrice { get; set; }

        public int unitsInStock { get; set; }

        public int unitsOnOrder { get; set;}
        public int reOrderLevel { get; set;}

        public bool Distcotinued { get; set; }

        public string supplier { get; set; }
    }
}
