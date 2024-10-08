using asp_servicios.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {

        [HttpGet(Name = "GetPersonas")]
        public IEnumerable<Personas> Get()
        {
            var conexion = new Conexion();
            conexion.StringConnection = @"server=localhost;database=pagos_db;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();

            conexion.Guardar(new Personas()
            {
                Cedula = "1127574583",
                Nombre = "Sebastian",
                Apellido = "Fuentes",
                Fecha = DateTime.Now,
            });
            conexion.SaveChanges();
            return conexion.Listar<Personas>();
        }
    }
}