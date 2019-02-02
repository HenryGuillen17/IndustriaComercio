
using System;
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class Deuda 
    {
        public int DeclaracionId { get; set; }
        public byte NoCuota { get; set; }
        public short Año { get; set; }
        public double TotalCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }
        
        public virtual Declaracion Declaracion { get; set; }
    }
}