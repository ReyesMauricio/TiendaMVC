using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }

        [Display(Name = "Numero documento")]
        public string Numero_documento { get; set; }

        public string Direccion { get; set; }
        public bool Estado { get; set; }

        public int IdTipoDocumento { get; set; }

        public virtual Tipo_documento Tipo_documento { get; set; }

        public ICollection<Venta> Ventas { get; set; }

    }
}