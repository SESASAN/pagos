using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_servicios.Nucleo
{
    public class Pagos
    {
        [Key] public int Id { get; set; }
        public int PersonaId {  get; set; }
        [ForeignKey("PersonaId")]

        public virtual Personas PersonaID { get; set; }
        public decimal Precio { get; set; }

    }
}
