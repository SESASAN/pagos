using asp_servicios.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagosController : ControllerBase
    {

        [HttpGet(Name = "GetPagos")]
        public IEnumerable<Pagos> Get()
        {
            var conexion = new Conexion();
            conexion.StringConnection = @"server=localhost;database=pagos_db;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();

            conexion.Guardar(new Pagos()
            {
                PersonaId = 1,
                Precio = 10000
            });
            conexion.SaveChanges();
            return conexion.Listar<Pagos>();
        }

        [HttpPost]
        public decimal calcularPromedioPagos()
        {
            var conexion = new Conexion();
            conexion.StringConnection = @"server=localhost;database=pagos_db;Integrated Security=True;TrustServerCertificate=true;";
            decimal prom = 0;
            var pepe = conexion.Listar<Pagos>();

            foreach (var x in pepe)
            {

                prom += x.Precio;
            }

            return prom / pepe.Count();

        }

        [HttpPost]
        public int contarPersonasPagos()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=localhost;database=pagos_db;Integrated Security=True;TrustServerCertificate=true;";
            var pepe = conexion.Listar<Pagos>();

            List<int> ints = new List<int>();

            foreach (var x in pepe)
            {

                ints.Add(x.PersonaId);

            }


            return ints.Distinct().Count();

        }

    }
}