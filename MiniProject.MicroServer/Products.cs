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

namespace MiniProject.MicroServer
{
    public static class Products
    {
        [FunctionName("Products")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            if (req.Method == "GET")
            {
                return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.product.getProductFromDB()));
            }
            else if (req.Method == "POST")
            {
                UserMessage data = new UserMessage();
                data = System.Text.Json.JsonSerializer.Deserialize<UserMessage>(req.Body);
                MainManager.Instance.message.SendNewInputToDataLayer(data);
            }


            return null;
        }
    }
}
