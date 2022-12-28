using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MiniProject.Entity;
using System.Text.Json;
using MiniProject.Model;
using MiniProject.Data.Sql;
using System.Collections.Generic;

namespace MiniProject.MicroServer
{
    public static class Products
    {
        [FunctionName("Products")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post","delete", Route = "Users/{action}/{IdNumber?}")] HttpRequest req,
            string action, string IdNumber, ILogger log)
        {
            string requestBody;

            switch (action)
            {
                case "ADD":
                    UserMessage data = new UserMessage();
                    data = System.Text.Json.JsonSerializer.Deserialize<UserMessage>(req.Body);
                    MainManager.Instance.message.SendNewInputToDataLayer(data);

                    break;
                case "GET":
                            return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.product.getProductFromDB()));
                    break;

                case "GETONE":
                    
                    Model.Product p = MainManager.Instance.product.getProductByIDFromDB(IdNumber);
                    return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(p));

                    break;
                case "UpdateOne":
                    try
                    {

                        requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                        Model.Product product = System.Text.Json.JsonSerializer.Deserialize<Model.Product>(requestBody);
                        MainManager.Instance.product.UpdateAProductInDb(product.productID, product.categoryID, product.unitsInStock);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    break;
                case "DELETE":

                    MainManager.Instance.product.DeleteAProductByProductID(int.Parse(IdNumber));

                    break;

                default:
                    break;

            }


            return null;
        }
    }
}
