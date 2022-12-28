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

        public Product getProductByIDFromDB(string productID)
        {
            Data.Sql.Product product = new Data.Sql.Product();
            return (Model.Product)product.SendSqlQueryToReadFromDBForOneProduct(productID);
            
            
        }

        public void UpdateAProductInDb(int productID, int categoryID, int unitsInStock)
        {
            Data.Sql.Product product = new Data.Sql.Product();
           product.UpdateAProduct(productID, categoryID, unitsInStock);
        }

        public void DeleteAProductByProductID(int productID)
        {
            Data.Sql.Product product = new Data.Sql.Product();
            product.DeleteProduct(productID);
        }

    }
}
