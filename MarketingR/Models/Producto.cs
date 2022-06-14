using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MarketingR.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [Display(Name = "Nombre del producto")]
        public string Nombre_producto { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo {0}, no puede estar vacio")]
        public int Cantidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime Ultima_compra { get; set; }

        public float Existencias { get; set; }

        public int IdCategoria { get; set; }
        public Categoria oCategoria { get; set; }

        public ICollection<Detalle_venta> Detalles_Ventas { get; set; }

    }
}