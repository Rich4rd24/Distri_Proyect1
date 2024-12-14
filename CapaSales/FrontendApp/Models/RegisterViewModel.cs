using System.ComponentModel.DataAnnotations;

namespace FrontendApp.Models
{
    public class RegisterViewModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public string LugarNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public string Ocupacion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public int IdRol { get; set; } = 3; // Rol asignado automáticamente
    }
}