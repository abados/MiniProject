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

        //Global Hashtable
        public Dictionary<string, Product> ProductsList = new Dictionary<string, Product>();

        // get data from sql server and insert it into hashtable
        public object ReadFromDb(SqlDataReader reader)
        {
            //Clear Hashtable Before Inserting Information From Sql Server
            ProductsList.Clear();
            object retDict = null;
            while (reader.Read())
            {
                Product product = new Product();
                product.productID = reader.GetInt32(0);
                product.productName = reader.GetString(1);
                product.supplierID = reader.GetInt32(2);
                product.categoryID = reader.GetInt32(3);
                product.quantityPerUnit= reader.GetString(4);
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

            retDict = ProductsList;
            return retDict;
        }
        //Function that helps connect between UI and DAL and return Hashtable
        public object SendSqlQueryToReadFromDB(string SqlQuery)
        {

            object retDict = null;
            retDict = DAL.SqlQuery.StartReadFromDB(SqlQuery, ReadFromDb);
            return retDict;
        }
    }
}
