
namespace EnvioCorreos.Servicios
{
    public interface IServicioEmail
    {
        Task EnviarEmail(string emailReceptor, string tema, string cuerpo);
    }
}