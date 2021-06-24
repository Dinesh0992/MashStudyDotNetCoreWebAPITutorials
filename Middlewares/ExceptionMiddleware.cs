using System.Net;
using System;
using System.Threading.Tasks;
using MashStudyDotNetCoreWebAPITutorials.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace MashStudyDotNetCoreWebAPITutorials.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IWebHostEnvironment env;

        public ExceptionMiddleware(
                                    RequestDelegate next
                                   , ILogger<ExceptionMiddleware> logger
                                   , IWebHostEnvironment env
                                   )
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);

            }
            catch (Exception ex)
            {
                int statusCode=(int)HttpStatusCode.InternalServerError;
                ApiError response=new ApiError(statusCode,ex.Message,env.IsDevelopment()?ex.StackTrace:null );
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = statusCode;
                context.Response.ContentType="application/json";
                await context.Response.WriteAsync(response.ToString());

            }

        }
    }
}
