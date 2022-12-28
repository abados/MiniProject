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

        public  MiniProject.Model.Product ReadOneFromDb(SqlDataReader reader)
        {

            MiniProject.Model.Product product = new MiniProject.Model.Product();
            while (reader.Read())
            {
               
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


            }
            return product;
        }
        public object SendSqlQueryToReadFromDB()
        {
            string SqlQuery = "select * from NewProductTable";
            object retDict = null;
            retDict = DAL.SqlQuery.StartReadFromDB(SqlQuery, ReadFromDb);
            return retDict;
        }

        public object SendSqlQueryToReadFromDBForOneProduct(string productID)
        {
            string SqlQuery = "select * from Products where ProductID = '" + productID + "'";
            object retObject = DAL.SqlQuery.StartReadFromDB(SqlQuery, ReadOneFromDb);
            return retObject;


        }

        public void UpdateAProduct(int productID, int categoryID, int unitsInStock)
        {


            string updateQuery = "update NewProductTable set CategoryID = @categoryID, UnitsInStock = @unitsInStock where ProductID = @productID";
            DAL.SqlQuery.UpdateRowById(updateQuery, productID, categoryID, unitsInStock);

        }

        public void DeleteProduct(int productID)
        {
          

            string deleteQuery = "delete from NewProductTable where ProductID = @productID ";
            DAL.SqlQuery.DeleteFromSqlServer(deleteQuery, productID);


        }
    }
}
