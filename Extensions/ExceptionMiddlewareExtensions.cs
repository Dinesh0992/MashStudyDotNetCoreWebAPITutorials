using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using MashStudyDotNetCoreWebAPITutorials.Middlewares;

namespace MashStudyDotNetCoreWebAPITutorials.Extensions
{
    public  static class ExceptionMiddlewareExtensions
    {

         public static void ConfigureExceptionCatcher( this IApplicationBuilder app, IWebHostEnvironment env){
            app.UseMiddleware<ExceptionMiddleware>();
         }
        public static void ConfigureBuiltInExceptionCatcher( this IApplicationBuilder app, IWebHostEnvironment env)
        {
             if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseSwagger();
               // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MashStudyDotNetCoreWebAPITutorials v1"));
            }
            else 
            {
                app.UseExceptionHandler(options=>{
                    options.Run(
                        async  context =>
                        {
                            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                            var ex=context.Features.Get<IExceptionHandlerFeature>();
                            if(ex!=null)
                            {
                                await context.Response.WriteAsync(ex.Error.Message);
                            }
                        }

                    );
                });

            }
        }
        
    }
}
