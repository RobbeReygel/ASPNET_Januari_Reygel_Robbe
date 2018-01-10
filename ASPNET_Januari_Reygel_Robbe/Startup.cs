using System;
using ASPNET_Januari_Reygel_Robbe.Controllers;
using ASPNET_Januari_Reygel_Robbe.Data;
using ASPNET_Januari_Reygel_Robbe.Entities;
using ASPNET_Januari_Reygel_Robbe.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNET_Januari_Reygel_Robbe
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
            //services.AddDbContext<EntityContext>(options => options.UseInMemoryDatabase("Cars"));
            services.AddDbContext<EntityContext>(options =>
                options.UseSqlite("Data Source=Car.db"));

            services.AddScoped<ICarService, CarService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EntityContext entityContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            DatabaseInitializer.InitializeDatabase(entityContext);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
