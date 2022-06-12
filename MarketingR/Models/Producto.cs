using System;
using System.ComponentModel.DataAnnotations;
namespace MarketingR.Models
{
    public class Producto
    {
        [Key]
        public int Id_producto { get; set; }

        [Required]
        [Display(Name = "Nombre del producto")]
        public string Nombre_producto { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        public int Cantidad { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime Ultima_compra { get; set; }

        public float Existencias { get; set; }
    
    }
}