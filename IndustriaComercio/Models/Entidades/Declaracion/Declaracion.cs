
using IndustriaComercio.Entidades.Persona;
using System;
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class Declaracion 
    {
        public int DeclaracionId { get; set; }
        public int EstablecimientoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaDeclaracion { get; set; }
        public short AñoGravable { get; set; }
        public double TotalIngresos { get; set; }
        public double TotalLiquidacion { get; set; }
        public string Observacion { get; set; }

        public virtual Establecimiento Establecimiento { get; set; }
        //public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DeclaracionDetalle> DeclaracionDetalles { get; set; }
        //public virtual ICollection<Deuda> Deudas { get; set; }
    }
}