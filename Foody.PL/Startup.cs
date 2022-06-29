using Foody.BLL;
using Foody.BLL.Services;
using Foody.DAL.EF;
using Foody.DAL.Interfaces;
using Foody.DAL.Repositories;
using Foody.PL.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foody.PL
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


            //// use in-memory database
            //services.AddDbContext<AspnetRunContext>(c =>
            //    c.UseInMemoryDatabase("AspnetRunConnection"));

            // use real database
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<APIContext>(/*options => options.UseMySql(mySqlConnectionStr, 
                                                                            ServerVersion.AutoDetect(mySqlConnectionStr))*/);

            //services.AddDbContext<APIContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("AspnetRunConnection")));


            //services.AddSingelton<UnitOfWork>(o => Configuration.GetConnectionString("ConnectionString"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddOptions<DataServiceOptions>()
                .Bind(Configuration.GetSection(DataServiceOptions.Tokens))
                .ValidateDataAnnotations();

            services.AddScoped<IDataService, DataService>();
            services.AddScoped<UsersController>();
            services.AddScoped<MealsController>();
            services.AddScoped<UsersServiceController>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodyAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodyAPI v1"));


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
