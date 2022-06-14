using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Tipo_documento
    {
        [Key]
        [Display(Name = "Tipo documento")]
        public int IdTipoDocumento { get; set; }

        [Required]
        [Display(Name = "Documento")]
        public string Descripcion { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
        
        public ICollection<Cliente> Clientes { get; set; }
    }
}