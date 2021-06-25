//using System.Net;
using MashStudyDotNetCoreWebAPITutorials.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MashStudyDotNetCoreWebAPITutorials.Interfaces;
using MashStudyDotNetCoreWebAPITutorials.Helpers;
// using Microsoft.AspNetCore.Diagnostics;
// using Microsoft.AspNetCore.Http;
using MashStudyDotNetCoreWebAPITutorials.Extensions;
using MashStudyDotNetCoreWebAPITutorials.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MashStudyDotNetCoreWebAPITutorials
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MashStudyDotNetCoreWebAPITutorials", Version = "v1" });
            });
            services.AddDbContext<DataContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("StudyMashWebAPIConnectionStrings")));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            string secretkey=Configuration.GetSection("AppSettings:Key").Value;
              var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>{
                opt.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateIssuerSigningKey=true,
                    ValidateIssuer=false,
                    ValidateAudience=false,
                    IssuerSigningKey=key
                };
            });
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          app.ConfigureExceptionCatcher(env);
        //  app.UseMiddleware<ExceptionMiddleware>();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MashStudyDotNetCoreWebAPITutorials v1"));

            app.UseRouting();
            app.UseCors(m=>m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
