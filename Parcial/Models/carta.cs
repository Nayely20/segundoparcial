using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Models
{
    public class carta
    {
        [Key]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "escriba de nuevo")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "La longitud de {0} debe estar entre {2} y {1}")]
        public string Letra { get; set; }
        [Url]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La longitud de {0} debe estar entre {2} y {1}")]
        public string Enlace { get; set; }


    }
}
