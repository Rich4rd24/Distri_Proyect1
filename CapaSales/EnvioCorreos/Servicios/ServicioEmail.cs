using System.Net;
using System.Net.Mail;

namespace EnvioCorreos.Servicios
{
    public class ServicioEmail : IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task EnviarEmail(string emailReceptor, string tema, string cuerpo)
        {
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            var smtCliente = new SmtpClient(host, puerto);
            smtCliente.EnableSsl = true;
            smtCliente.UseDefaultCredentials = false;

            smtCliente.Credentials = new NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage(emailEmisor, emailReceptor, tema, cuerpo);
            await smtCliente.SendMailAsync(mensaje);

        }
    }
}
