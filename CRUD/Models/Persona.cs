using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Persona
    {
        [Required(ErrorMessage ="Campo requerido")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Direccion { get; set; }
   
    }
}
