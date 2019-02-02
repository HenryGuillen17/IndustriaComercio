
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class Concepto 
    {
        public int ConceptoId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public short TipoConceptoId { get; set; }

        public virtual TipoConcepto TipoConcepto { get; set; }
        public virtual ICollection<Descuento> Descuentos { get; set; }
        public virtual ICollection<DeclaracionDetalle> DeclaracionDetalles { get; set; }
    }
}