using EnvioCorreos.Servicios;
using Microsoft.AspNetCore.Mvc;

[Route("api/emails")]
[ApiController]
public class EmailsController : ControllerBase
{
    private readonly IServicioEmail servicioEmail;

    public EmailsController(IServicioEmail servicioEmail)
    {
        this.servicioEmail = servicioEmail;
    }

    [HttpPost("enviar")]
    public async Task<ActionResult> Enviar(string email, string tema, string cuerpo)
    {
        await servicioEmail.EnviarEmail(email, tema, cuerpo);
        return Ok(new { Message = "Correo enviado correctamente." });
    }
}
