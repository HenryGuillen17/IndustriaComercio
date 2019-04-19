
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class DeudaDetalle 
    {
        public int DeclaracionId { get; set; }
        public byte NoCuota { get; set; }
        public int Id { get; set; }
        public int ConceptoId { get; set; }
        public double Valor { get; set; }
        public double Abono { get; set; }
        public bool Pagado { get; set; }
        public string NoRecibo { get; set; }

        public virtual Concepto Concepto { get; set; }
        public virtual Declaracion Declaracion { get; set; }
    }
}