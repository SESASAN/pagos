using System.ComponentModel.DataAnnotations;

namespace asp_servicios.Nucleo
{
    public class Personas
    {
        [Key] public int PersonaId { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime Fecha { get; set; }

    }
}
