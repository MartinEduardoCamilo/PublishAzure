using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;
using FunctionApp.Models;

namespace FunctionApp
{
    class CovidFAQ
    {
        [FunctionName("covidFAQ")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        [CosmosDB(
            databaseName:"MDB",
            collectionName:"FAQContainer",
            ConnectionStringSetting = "DBConnectionString"
            )] IEnumerable<FAQ> questionSet,
        ILogger log)
        {
            log.LogInformation("Data fetched from FAQContainer");
            return new OkObjectResult(questionSet);
        }
    }
}