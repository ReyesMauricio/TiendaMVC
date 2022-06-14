using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}