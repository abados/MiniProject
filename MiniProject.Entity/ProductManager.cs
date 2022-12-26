using MiniProject.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Entity
{
    public class ProductManager
    {

        //Global Dictionary
        public Dictionary<string, Product> ProductsList = new Dictionary<string, Product>();

        public Dictionary<string, Product> getProductFromDB()
        {
            Data.Sql.Product product = new Data.Sql.Product();
            ProductsList = (Dictionary<string, Product>)product.SendSqlQueryToReadFromDB();
            return ProductsList;
        }
       
    }
}
