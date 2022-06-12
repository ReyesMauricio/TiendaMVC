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
        public int Id_empleado { get; set; }

        [Required(ErrorMessage ="El campo {0}, no puede estar vacio")]
        [StringLength(30, ErrorMessage ="El campo {0} necesita entre {2} y {1} caracteres", MinimumLength =3)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        [StringLength(30, ErrorMessage = "El campo {0} necesita entre {2} y {1} caracteres", MinimumLength = 4)]
        public string Apellidos { get; set; }

        public string Nombre_Completo { get { return string.Format("{0} {1}", Nombres, Apellidos); } }

        [Display(Name ="Porcentaje de bonificacion")]
        public float Porcentaje_bonificado { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        [Display(Name ="Hora de inicio")]
        [DataType(DataType.Time)]
        public DateTime Hora_inicio { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        public int Id_tipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        [Display(Name = "Numero documento")]
        public string Numero_documento { get; set; }

        [NotMapped]
        public int Edad { get { return DateTime.Now.Year - FechaNacimiento.Year; } }

        public virtual Tipo_documento Tipo_documento { get; set; }
    }
}
