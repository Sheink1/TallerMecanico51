using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taller.Core.Models.Entidades;
using Taller.Web.Data;
using Taller.Web.Interface;

namespace Taller.Web
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
            services.AddTransient<IBaseDatos<Marca>,BaseDatos<Marca>>();
            services.AddTransient<IBaseDatos<Modelo>,BaseDatos<Modelo>>();
            services.AddTransient<IBaseDatos<Cliente>,BaseDatos<Cliente>>();
            services.AddTransient<IBaseDatos<Mecanico>,BaseDatos<Mecanico>>();
            services.AddTransient<IBaseDatos<Servicio>,BaseDatos<Servicio>>();
            services.AddTransient<IBaseDatos<OrdenServicio>,BaseDatos<OrdenServicio>>();
            services.AddTransient<IBaseDatos<OrdenServicioDetalleTemporal>,BaseDatos<OrdenServicioDetalleTemporal>>();
           

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
