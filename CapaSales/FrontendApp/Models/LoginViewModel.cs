﻿using System.ComponentModel.DataAnnotations;

namespace FrontendApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [Display(Name = "Correo Electrónico")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}