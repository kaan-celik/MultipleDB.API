using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDB.API.Middleware
{
    public class RequestResponseMiddeware
    {
        private RequestDelegate next;
        private ILogger<ExceptionHandlerMiddleware> logger;

        public RequestResponseMiddeware(RequestDelegate Next, ILogger<ExceptionHandlerMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }


        public async Task Invoke(HttpContext context)
        {
            var originalBody = context.Response.Body;
            logger.LogInformation($"Query Keys:{context.Request.QueryString}");

            MemoryStream requestBody = new MemoryStream();
            await context.Request.Body.CopyToAsync(requestBody);
            requestBody.Seek(0, SeekOrigin.Begin);
            
            String requestText = await new StreamReader(requestBody).ReadToEndAsync();
            requestBody.Seek(0, SeekOrigin.Begin);



            MemoryStream tempStream = new MemoryStream();
            context.Response.Body = tempStream;

            await next.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            String responseText = await new StreamReader(context.Response.Body, Encoding.UTF8).ReadToEndAsync();
            
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await context.Request.Body.CopyToAsync(originalBody);

            logger.LogInformation($"Request: {requestText}");
            logger.LogInformation($"Response: {responseText}");
        }
    }
}
