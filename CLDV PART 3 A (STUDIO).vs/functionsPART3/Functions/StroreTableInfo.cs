
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
namespace CLDV_PART_3_A__STUDIO_.Functions
{
    public static class StoreTableInfo
    {
        [Function("StoreTableInfo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string tableName = req.Query["tableName"];
            string partitionKey = req.Query["partitionKey"];
            string rowKey = req.Query["rowKey"];
            string data = req.Query["data"];

            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(partitionKey) || string.IsNullOrEmpty(rowKey) || string.IsNullOrEmpty(data))
            {
                return new BadRequestObjectResult("Table name, partition key, row key, and data must be provided.");
            }

           

            return new OkObjectResult("Data added to table");
        }
    }
}