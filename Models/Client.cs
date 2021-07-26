using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_davivienda_cliente.Models
{
    public class Client
    {
        [Required(ErrorMessage = "El número de identificacion es un parametro requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar un valor valido para el número de identificación.")]
        public int idIdentificacion { get; set; }

        [Required(ErrorMessage = "El nombre es un parametro requerido.")]
        [MinLength(1, ErrorMessage = "Número de caracteres invalidos.")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La direccion es un parametro requerido.")]
        [MinLength(1, ErrorMessage ="Número de caracteres invalidos.")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "El telefono es un parametro requerido.")]
        [MinLength(1, ErrorMessage = "Número de caracteres invalidos.")]
        public string telefono { get; set; }
    }
}
