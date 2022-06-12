using MarketingR.Models;
using System.Data.Entity;

namespace MarketingR.Context
{
    public class MarketingContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Tipo_documento> Tipo_documentos { get; set; }
    }
}