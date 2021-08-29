using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisinessLogicLayer.ProvidedServices;
using BuisinessLogicLayer.Repositories;
using DataAccessLayer;
using DataAccessLayer.ProvidedServices;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RecycleAppBackend
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
            services.AddDbContext<DataBaseContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:RecyclingDataBase"]));
            services.AddScoped<IUserRepositoryDAL, UserRepositoryDAL>();
            services.AddScoped<IUserRepositoryBLL, UserRepositoryBLL>();
            services.AddScoped<IMaterialRepositoryDAL, MaterialRepositoryDAL>();
            services.AddScoped<IMaterialRepositoryBLL, MaterialRepositoryBLL>();
            services.AddScoped<IMaterialTypeRepositoryDAL, MaterialTypeRepositoryDAL>();
            services.AddScoped<IMaterialTypeRepositoryBLL, MaterialTypeRepositoryBLL>();
            services.AddScoped<ISeparationSugestionRepositoryDAL, SeparationSugestionRepositoryDAL>();
            services.AddScoped<ISeparationSugestionRepositoryBLL, SeparationSugestionRepositoryBLL>();
            services.AddScoped<IRequestRepositoryDAL, RequestRepositoryDAL>();
            services.AddScoped<IRequestRepositoryBLL, RequestRepositoryBLL>();

            services.AddCors(o => o.AddPolicy("CustomPolicy", builder =>
            {
                builder
                       .AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddMvc().AddJsonOptions(opt=>opt.JsonSerializerOptions.PropertyNamingPolicy=null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CustomPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
