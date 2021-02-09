using Microsoft.EntityFrameworkCore;
using Taller.Core.Models.Entidades;

namespace Taller.Api.Data{

    public class TallerContext:DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options) : base(options)
        {

        }

        public DbSet<Marca> Marca {get; set;}

        public DbSet<Modelo> Modelo {get; set;}

        public DbSet<Cliente> Cliente {get; set;}

        public DbSet<Mecanico> Mecanico {get;set;}

        public DbSet<Servicio> Servicio {get;set;}

        public DbSet<OrdenServicio> OrdenServicio {get; set;}

        public DbSet<OrdenServicioDetalleTemporal> OrdenServicioDetalleTemporal {get; set;}
    }
}