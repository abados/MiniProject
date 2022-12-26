using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProject.Model;

namespace MiniProject.Data.Sql
{
    public class Product
    {
        
        public Dictionary<string, MiniProject.Model.Product> ReadFromDb(SqlDataReader reader)
        {
         Dictionary<string, MiniProject.Model.Product> ProductsList = new Dictionary<string, MiniProject.Model.Product>();

        //Clear Hashtable Before Inserting Information From Sql Server
        ProductsList.Clear();
            
            while (reader.Read())
            {
                MiniProject.Model.Product product = new MiniProject.Model.Product();
                product.productID = reader.GetInt32(0);
                product.productName = reader.GetString(1);
                product.supplierID = reader.GetInt32(2);
                product.categoryID = reader.GetInt32(3);
                product.quantityPerUnit = reader.GetString(4);
                product.unitPrice = reader.GetDecimal(5);
                product.unitsInStock = reader.GetInt16(6);
                product.unitsOnOrder = reader.GetInt16(7);
                product.reOrderLevel = reader.GetInt16(8);
                product.Distcotinued = reader.GetBoolean(9);


                //Cheking If Hashtable contains the key
                if (ProductsList.ContainsKey(product.productName))
                {
                    //key already exists
                }
                else
                {
                    //Filling a hashtable
                    ProductsList.Add(product.productName, product);
                }

            }
            return ProductsList;
        }
        public object SendSqlQueryToReadFromDB()
        {
            string SqlQuery = "select * from Products";
            object retDict = null;
            retDict = DAL.SqlQuery.StartReadFromDB(SqlQuery, ReadFromDb);
            return retDict;
        }
    }
}
