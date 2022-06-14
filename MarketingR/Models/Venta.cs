using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente oCliente { get; set; }


        [DataType(DataType.Date)]
        public DateTime FechaVenta { get; set; }

        public double Impuesto { get; set; }
        
        public double TotalVenta { get; set; }

        public ICollection<Detalle_venta> Detalle_Ventas { get; set; }

    }
}