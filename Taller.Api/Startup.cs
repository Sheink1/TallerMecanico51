using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Taller.API.Data;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using Taller.API.Intefaces;
using Taller.Core.Models.Entidades;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Taller.API
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
            services.AddDbContext<TallerContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Taller")));
            
            services.AddTransient<IBaseDatos<Marca>,BaseDatos<Marca>>();
            services.AddTransient<IBaseDatos<Modelo>,BaseDatos<Modelo>>();
            services.AddTransient<IBaseDatos<Cliente>,BaseDatos<Cliente>>();
            services.AddTransient<IBaseDatos<Mecanico>,BaseDatos<Mecanico>>();
            services.AddTransient<IBaseDatos<OrdenServicio>,BaseDatos<OrdenServicio>>();
            services.AddTransient<IBaseDatos<Servicio>,BaseDatos<Servicio>>();
            services.AddTransient<IBaseDatos<OrdenServicioDetalleTemporal>,BaseDatos<OrdenServicioDetalleTemporal>>();

            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1",new OpenApiInfo { Title = "Taller api v1", Version = "v1" });
            }
            );

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(Option =>{
             Option.SwaggerEndpoint("/swagger/v1/swagger.json","Taller api v1");
             Option.RoutePrefix=string.Empty;
             Option.DefaultModelRendering(ModelRendering.Example);
             
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}