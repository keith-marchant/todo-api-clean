using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using TodoApp.Application.Items.Queries.GetItems;
using TodoApp.Application.Enums;
using TodoApp.Application.Items.Commands.CreateItem;
using TodoApp.Application.Items.Queries.GetItemById;
using Newtonsoft.Json.Linq;

namespace TodoApp.Function
{
    public class TodoApp
    {
        private readonly IMediator _mediator;

        public TodoApp(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("GetItems")]
        public async Task<IActionResult> GetItems(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "items")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {

            var query = new GetItemsQuery(null, null, null);

            var result = await _mediator.Send(query, cancellationToken);

            return new OkObjectResult(result);
        }

        [FunctionName("CreateItem")]
        public async Task<IActionResult> CreateItem(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "items")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            try
            {
                using (StreamReader reader = new StreamReader(req.Body))
                {
                    var json = await reader.ReadToEndAsync();
                    var title = JObject.Parse(json)["Title"].ToString();

                    var command = new CreateItemCommand(title, null, null);

                    var result = await _mediator.Send(command, cancellationToken);

                    return new OkObjectResult(result);
                }
            }
            catch(Exception ex)
            {
                log.LogError(ex, "Failed to create item");
            }

            return new BadRequestObjectResult("Failed to validate request.");
        }

        [FunctionName("GetItemById")]
        public async Task<IActionResult> GetItemById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "items/{itemId:int}")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetItemByIdQuery(int.Parse(req.Path.Value.Substring(req.Path.Value.LastIndexOf("/") + 1))), cancellationToken);

                return new OkObjectResult(result);
            }
            catch
            {
                return new NotFoundResult();
            }
        }
    }
}
