using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Models
{
    public class carta   
 // NaipeId -> contiene de la A al naipe K

//Nombre -> Nombre de la Carta





    {
        [Key]

        public string NaipeId { get; set; }
        [Required(ErrorMessage = "contiene de la A al naipe K")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "La longitud de {0} debe estar entre {2} y {1}")]
        public string Imagen { get; set; }
        [Url]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La longitud de {0} debe estar entre {2} y {1}")]
        public string Enlace { get; set; }


    }
}
