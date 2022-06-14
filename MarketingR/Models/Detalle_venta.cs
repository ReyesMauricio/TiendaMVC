using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Detalle_venta
    {
        [Key]
        public int IdDetalleVenta { get; set; }

        public int IdVenta { get; set; }

        public virtual Venta oVenta { get; set; }

        public int IdProducto { get; set; }

        public virtual Producto oProducto { get; set; }

        public int Cantidad { get; set; }

        public double PrecioVenta { get; set; }
    }
}