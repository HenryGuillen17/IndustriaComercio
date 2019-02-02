
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class TipoConcepto
    {
        public short TipoConceptoId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}