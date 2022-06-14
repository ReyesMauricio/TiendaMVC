using MarketingR.Models;
using System.Data.Entity;

namespace MarketingR.Context
{
    public class MarketingContext : DbContext
    {
        public System.Data.Entity.DbSet<MarketingR.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.Tipo_documento> Tipo_documento { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.Empleado> Empleadoes { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.Producto> Productoes { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.Venta> Ventas { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.Detalle_venta> Detalle_venta { get; set; }
    }
}