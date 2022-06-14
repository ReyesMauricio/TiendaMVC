using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Numero documento")]
        public string Numero_documento { get; set; }

        public int IdTipoDocumento { get; set; }

        public virtual Tipo_documento Tipo_documento { get; set; }

    }
}
