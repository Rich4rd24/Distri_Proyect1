using FrontendApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Entities;

namespace FrontendApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            ILogger<AccountController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Encriptar la contraseña
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Contrasena);

                var persona = new
                {
                    nombre = model.Nombre,
                    apellido = model.Apellido,
                    genero = model.Genero,
                    lugar_nacimiento = model.LugarNacimiento,
                    nacionalidad = model.Nacionalidad,
                    estado_civil = model.EstadoCivil,
                    ocupacion = model.Ocupacion,
                    telefono = model.Telefono,
                    email = model.Email,
                    contrasena = hashedPassword, // Contraseña encriptada
                    id_rol = model.IdRol
                };

                var httpClient = _httpClientFactory.CreateClient("WebAPI");
                var content = new StringContent(
                    JsonConvert.SerializeObject(persona),
                    System.Text.Encoding.UTF8,
                    "application/json");

                var response = await httpClient.PostAsync("Persona/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al registrar el usuario.");
                }
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loginRequest = new LoginRequest
                    {
                        Username = model.Username,
                        Password = model.Password
                    };

                    var httpClient = _httpClientFactory.CreateClient("WebAPI");
                    var content = new StringContent(
                        JsonConvert.SerializeObject(loginRequest),
                        System.Text.Encoding.UTF8,
                        "application/json");

                    var response = await httpClient.PostAsync("Persona/Login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeAnonymousType(responseContent,
                            new { Success = false, User = new { id = 0, nombre = "", apellido = "", email = "", id_rol = 0 } });

                        if (result.Success)
                        {
                            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.User.nombre),
                        new Claim(ClaimTypes.Email, result.User.email),
                        new Claim(ClaimTypes.Role, result.User.id_rol.ToString()),
                        new Claim("UserId", result.User.id.ToString())
                    };

                            var claimsIdentity = new ClaimsIdentity(claims,
                                CookieAuthenticationDefaults.AuthenticationScheme);

                            var authProperties = new AuthenticationProperties
                            {
                                IsPersistent = true,
                                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                            };

                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties);

                            return RedirectToAction("Index", "Home");
                        }
                    }

                    ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al intentar iniciar sesión");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}