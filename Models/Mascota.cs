using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenU2.Models
{
    public class Mascota
    {
         [Required(ErrorMessage = "Se necesita el numero de identificacion")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Se requiere un tipo")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Se requiere una raza")]
        public string Raza { get; set; }
        [Required(ErrorMessage = "Se requiere un nombre")]
        public string Nombre { get; set; }
        public int? Edad { get; set; }
    }
}
