#r "Newtonsoft.Json"
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];

    if (string.IsNullOrEmpty(name))
    {
        using var reader = new StreamReader(req.Body);
        var data = JsonConvert.DeserializeObject<dynamic>(await reader.ReadToEndAsync());
        name = data?.name;
    }

    return new OkObjectResult($"Hello, {name}. This HTTP triggered function executed successfully.");
}
