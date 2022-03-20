using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MultipleDB.API.Business.Entities;
using MultipleDB.API.Business.Interfaces;
using MultipleDB.API.Database.Mongo;
using MultipleDB.API.Database.Postgres;
using MultipleDB.API.Extensions;
using MultipleDB.API.Middleware;
using MultipleDB.API.Settings;
using MultipleDB.API.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API
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
            services.AddControllers();

            services.AddHealthChecks();
            
            services.AddLogging();

            var sqlConnectionString = Configuration["PostgreSqlConnectionString"];

            services.Configure<MongoSettings>(Configuration.GetSection(nameof(MongoSettings)));
            services.AddSingleton<IDBSettings>(t => t.GetRequiredService<IOptions<MongoSettings>>().Value);

            services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(sqlConnectionString));
            services.AddSingleton<IDBContext, PostgresConnection>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<RequestResponseMiddeware>();
            app.UseCustomHealthCheck();
            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
